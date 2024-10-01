using Microsoft.AspNetCore.Http;
using System.Net.Http;
using GestioneStanze.ClientHttp.Abstractions;
using System.Net.Http.Json;

namespace GestioneStanze.ClientHttp;

public class ClientHttp : IClientHttp
{
    private readonly HttpClient _httpClient;

    public ClientHttp(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco, CancellationToken cancellationToken = default)
    {
        // Creiamo il contenuto per il body della richiesta
        var content = new StringContent(fase_del_gioco, System.Text.Encoding.UTF8, "application/json");

        // Chiamata PUT con body
        var response = await _httpClient.PutAsync($"api/{id}/cambia-fase", content, cancellationToken);

        //Console.WriteLine(response);

        return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<bool>(cancellationToken);
    }
}