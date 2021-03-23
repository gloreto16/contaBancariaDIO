using System;

namespace DIO.Banco
{
    public class Conta
    {
        private string Nome { get;set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }
        private Pagamentos Pagamentos { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1)){
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            
            Console.WriteLine("Saldo atual da conta de {0} é R${1}", this.Nome, this.Saldo);

            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é R${1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }
        
        public void Pagar(double valorPagar, Pagamentos pagamento)
        {
            Console.WriteLine("A Conta de {0} foi paga no valor de R${1}.", pagamento, valorPagar);
        }
        
        public void Recarregar(double valorPagar, int ddd, int numeroCelular)
        {
            Console.WriteLine("A recarga no valor de R${0} para o número ({1}){2} foi efetuada com sucesso.", valorPagar, ddd, numeroCelular);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo da Conta: " + this.TipoConta + " || ";
            retorno += "Nome: " + this.Nome + " || ";
            retorno += "Saldo: R$" + this.Saldo + " || ";
            retorno += "Credito: R$" + this.Credito;
            return retorno;
        }
    }
}