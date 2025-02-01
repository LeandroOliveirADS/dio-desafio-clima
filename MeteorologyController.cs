using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
public class MeteorologyController : ControllerBase
{
    [HttpGet]
    public IActionResult RetrieveWeatherData(
        [FromQuery] string pais,
        [FromQuery] string estado)
    {
        // Verifica a presença dos parâmetros obrigatórios
        if (string.IsNullOrWhiteSpace(pais) || string.IsNullOrWhiteSpace(estado))
        {
            return BadRequest(new { mensagem = "É necessário informar o país e o estado." });
        }

        // Gera valores aleatórios para simular condições climáticas
        var gerador = new Random();
        var temperaturaSimulada = gerador.Next(15, 40); // De 15 a 40 graus
        var padroesClima = new[] { "Ensolarado", "Nublado", "Chuvoso", "Tempestade", "Nevoeiro" };
        var condicaoClima = padroesClima[gerador.Next(padroesClima.Length)];

        // Cria um objeto anônimo com as informações simuladas
        var dadosClima = new
        {
            Pais = pais,
            Estado = estado,
            Temperatura = $"{temperaturaSimulada}°C",
            Condicao = condicaoClima,
            Data = DateTime.UtcNow
        };

        // Retorna o objeto como resposta em JSON
        return Ok(dadosClima);
    }
}
