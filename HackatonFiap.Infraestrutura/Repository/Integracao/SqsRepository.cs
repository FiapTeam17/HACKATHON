using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Ponto.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HackatonFiap.Infraestrutura.Repository.Integracao;
public class SqsRepository : ISqsRepository
{
    private readonly HttpClient _httpClient;
    private readonly AmazonSQSClient _amazonSqsClient;
    private readonly IConfiguration _configuration;
    private readonly INotificador _notificador;
    private readonly ILogger<SqsRepository> _logger;

    public SqsRepository(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        INotificador notificador,
        ILogger<SqsRepository> logger)
    {
        _httpClient = httpClientFactory.CreateClient();
        _configuration = configuration;
        _notificador = notificador;
        _logger = logger;
    }

    public async Task SolicitarRelatorio(PeriodoModel periodoModel)
    {
        var awsAccessKey = _configuration["aws:ClientId"];
        var awsSecretKey = _configuration["aws:ClientSecret"];
        var awsRegion = RegionEndpoint.USEast2;

        // Criando uma instância do cliente SQS
        var sqsClient = new AmazonSQSClient(awsAccessKey, awsSecretKey, awsRegion);

        // Serializando o objeto em formato JSON
        var mensagemJson = JsonConvert.SerializeObject(periodoModel);

        // URL da fila do SQS
        var queueUrl = "https://sqs.us-east-2.amazonaws.com/190197150713/periodo.fifo"; // Substitua pelo URL da sua fila

        // Criando uma solicitação de envio de mensagem para a fila
        var sendMessageRequest = new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageBody = mensagemJson,
            MessageGroupId = "SolicitaRelatorio"
        };

        var sendMessageResponse = await sqsClient.SendMessageAsync(sendMessageRequest);
    }
}
