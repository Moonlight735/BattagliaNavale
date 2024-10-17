using Microsoft.AspNetCore.Http;
using System.Net.Http;
using GestioneUtente.ClientHttp.Abstractions;
using System.Net.Http.Json;

namespace GestioneUtente.ClientHttp;

public class ClientHttp : IClientHttp
{
    private readonly HttpClient _httpClient;

    public ClientHttp(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<bool> CambiaRuolo(int id, char nuovoRuolo, CancellationToken cancellationToken = default)
    {
        // Creiamo il contenuto per il body della richiesta
        var content = new StringContent(nuovoRuolo.ToString(), System.Text.Encoding.UTF8, "application/json");

        // Chiamata POST con body
        var response = await _httpClient.PostAsync($"api/{id}/cambia-ruolo", content, cancellationToken);


        return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<bool>(cancellationToken);
    }
}