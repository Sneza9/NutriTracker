using Backend.Data;
using Backend.Models;

public class UsdaApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly ApplicationDbContext _context;

    public UsdaApiService(HttpClient httpClient, IConfiguration configuration, ApplicationDbContext context)
    {
        _httpClient = httpClient;
        _apiKey = configuration["USDA:ApiKey"];
        _context = context;
    }

    public async Task<IngredientNutritionApi?> GetFoodDataAsync(string query)
    {
        // URL za USDA FoodData Central API
        string url = $"https://api.nal.usda.gov/fdc/v1/foods/search?query={query}&api_key={_apiKey}&dataType=Foundation";

        try
        {
            // Preuzimanje podataka u JSON formatu i deserializacija u konkretan tip
            var response = await _httpClient.GetFromJsonAsync<FoodResponse>(url);

            // Proveravamo da li postoji odgovor i da li ima podataka o hrani
            if (response?.Foods == null || response.Foods.Count == 0)
            {
                return null;
            }

            // Preuzimamo prvi element (ako postoji)
            var firstFood = response.Foods[0];

            var ingredient = new IngredientNutritionApi
            {
                FdcId = firstFood.FdcId,
                IngredientName = firstFood.Description,
                KCal = firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Energy")?.Value ?? 0m,
                Fat = firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Total lipid (fat)")?.Value ?? 0m,
                Carbohydrate = firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Carbohydrate, by difference")?.Value ?? 0m,
                Protein = firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Protein")?.Value ?? 0m
            };

            // Mapiranje podataka na objekat IngredientNutrition
            return ingredient;
        }
        catch (HttpRequestException ex)
        {
            // Ovdje možeš obraditi greške u slučaju neispravnog HTTP zahteva
            Console.WriteLine($"Error fetching data from USDA API: {ex.Message}");
            return null;
        }
    } 
}
