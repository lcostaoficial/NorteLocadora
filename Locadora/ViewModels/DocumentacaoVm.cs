using Microsoft.AspNetCore.Http;

namespace Locadora.ViewModels
{
    public enum IdentificadoDocumentacaoVm
    {
        Nenhum = 0,
        DocumentoDeContrato,
        DocumentoDeNadaConstaDetran,
        DocumentoDeNadaConstaCriminal,
        DocumentoDeCheckListSaida,
        DocumentoDeCheckListChegada,
        DocumentoDeIdentificacao,
        DocumentoDeComprovanteDeEndereco
    }

    public class DocumentacaoVm
    {
        public int LocacaoId { get; set; }

        public IFormFile DocumentoDeContrato { get; set; }       
        public string DocumentoDeContratoGet { get; private set; }   
        
        public IFormFile DocumentoDeNadaConstaDetran { get; set; }
        public string DocumentoDeNadaConstaDetranGet { get; private set; }

        public IFormFile DocumentoDeNadaConstaCriminal { get; set; }
        public string DocumentoDeNadaConstaCriminalGet { get; private set; }

        public IFormFile DocumentoDeCheckListSaida { get; set; }
        public string DocumentoDeCheckListSaidaGet { get; private set; }

        public IFormFile DocumentoDeCheckListChegada { get; set; }
        public string DocumentoDeCheckListChegadaGet { get; private set; }

        public IFormFile DocumentoDeIdentificacao { get; set; }
        public string DocumentoDeIdentificacaoGet { get; private set; }

        public IFormFile DocumentoDeComprovanteDeEndereco { get; set; }
        public string DocumentoDeComprovanteDeEnderecoGet { get; private set; }

        public bool Finalizada { get; set; }

        public bool ValidarDocumentacaoRetirada()
        {
            if (string.IsNullOrEmpty(DocumentoDeContratoGet))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeNadaConstaDetranGet))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeNadaConstaCriminalGet))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeCheckListSaidaGet))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeIdentificacaoGet))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeComprovanteDeEnderecoGet))
                return false;

            return true;
        }

        public void IncluirRotasSaida(string contrato, string ndConstaDetran, string ndConstaCriminal, string docCheckListaSaida, string docIdentificacao, string comprovanteEndereco)
        {
            DocumentoDeContratoGet = contrato;
            DocumentoDeNadaConstaDetranGet = ndConstaDetran;
            DocumentoDeNadaConstaCriminalGet = ndConstaCriminal;
            DocumentoDeCheckListSaidaGet = docCheckListaSaida;
            DocumentoDeIdentificacaoGet = docIdentificacao;
            DocumentoDeComprovanteDeEnderecoGet = comprovanteEndereco;
        }
    }
}