using System.Net.Http.Json;

public class ApiService
{
    private readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> RegisterUser(CreateUserDto user)
    {
        var response = await _http.PostAsJsonAsync("https://localhost:7191/api/Users", user);
        return response.IsSuccessStatusCode;
    }

    public async Task<UserResponseDto?> GetUser(int id)
    {
        return await _http.GetFromJsonAsync<UserResponseDto>($"https://localhost:7191/api/Users/{id}");
    }
}

public class CreateUserDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public UserProfileDto? UserProfile { get; set; }
}

public class UserProfileDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
}

public class UserResponseDto
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public UserProfileDto? UserProfile { get; set; }
}
