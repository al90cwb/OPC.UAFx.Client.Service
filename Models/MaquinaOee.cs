using System;
using System.ComponentModel.DataAnnotations;

namespace OPC.UAFx.Client.Service.Models;
public class MaquinaOee
{
        public Guid Id { get; set; } // Identificador único
        public string NomeProduto { get; set; } // Nome do produto (máx. 25 caracteres)
        public string NomeUsuario { get; set; } // Nome do usuário (máx. 25 caracteres)
        public int  EstadoMaquina { get; set; } // Estado da máquina (1 - Em Produção, 2 - Emergência, 3 - Parada, 4 - Manutenção, 5 - Espera)
        public uint ProducaoTotal { get; set; } // Total de produção
        public ulong CiclosTotal { get; set; } // Total de ciclos da máquina
        public ulong MinutosTotal { get; set; } // Total de minutos trabalhados
        public ulong RejeitosTotal { get; set; } // Total de rejeitos informados
        public DateTime CriadoEm { get; set; } // Data e hora da criação do dado

        public MaquinaOee()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Produto: {NomeProduto}\n" +
                   $"Usuário: {NomeUsuario}\n" +
                   $"Estado da Máquina: {EstadoMaquina}\n" +
                   $"Produção Total: {ProducaoTotal}\n" +
                   $"Ciclos Total: {CiclosTotal}\n" +
                   $"Minutos Total: {MinutosTotal}\n" +
                   $"Rejeitos Total: {RejeitosTotal}\n" +
                   $"Criado Em: {CriadoEm}";
        }
    }
