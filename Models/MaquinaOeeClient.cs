
using Opc.UaFx.Client;

namespace OPC.UAFx.Client.Service.Models;

public class MaquinaOeeClient : IDisposable
{
        private readonly OpcClient _client;
        private readonly AppDbContext _dbContext;
        public MaquinaOeeClient(string serverUrl, AppDbContext dbContext)
        {
            _client = new OpcClient(serverUrl); 
            _dbContext = dbContext;
        }

         public void Conectar()
        {
            _client.Security.UserIdentity = null;
            _client.Connect();
        }
        public MaquinaOee ColetarDados()
        {
            
            Opc.UaFx.OpcValue NomeProduto = _client.ReadNode("ns=2;s=GVL.oeeMaquina.nomeProduto");
            Opc.UaFx.OpcValue NomeUsuario = _client.ReadNode("ns=2;s=GVL.oeeMaquina.nomeUsuario");
            
            var dadosMaquina = new MaquinaOee
            {
                NomeProduto = NomeProduto.ToString(),
                NomeUsuario = NomeUsuario.ToString(),
                EstadoMaquina = Convert.ToInt32(_client.ReadNode("ns=2;s=GVL.oeeMaquina.estadoMaquina").Value),
                ProducaoTotal = Convert.ToUInt32(_client.ReadNode("ns=2;s=GVL.oeeMaquina.producaoTotal").Value),
                CiclosTotal = Convert.ToUInt64(_client.ReadNode("ns=2;s=GVL.oeeMaquina.ciclosTotal").Value),
                MinutosTotal = Convert.ToUInt64(_client.ReadNode("ns=2;s=GVL.oeeMaquina.minutosTotal").Value),
                RejeitosTotal = Convert.ToUInt64(_client.ReadNode("ns=2;s=GVL.oeeMaquina.rejeitosTotal").Value)
            };

            return dadosMaquina;
        }

        public void SalvarDados(MaquinaOee dadosMaquina)
        {
            _dbContext.MaquinaOees.Add(dadosMaquina);
            _dbContext.SaveChanges();
        }

        public void Desconectar()
        {
           _client.Disconnect();
        }
    public void Dispose()
        {
            _client?.Dispose();
        }
}
