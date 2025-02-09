﻿using Controle.Biblioteca.Interface;

namespace Controle.Biblioteca.Domain
{
    public class Usuario : INotificacaoObserver
    {
        public string Nome { get; }
        public int ID { get; }
        private static int contador = 1;

        public Usuario(string nome)
        {
            Nome = nome;
            ID = contador++;
        }

        public void Notificar(string mensagem)
        {
            Console.WriteLine($"Notificação para {Nome}: {mensagem}");
        }
    }
}
