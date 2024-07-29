using ApiRequest;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;


namespace ApiRequestBrasil
{

    public class DadosEmpresaBrasil
    {
        public static async Task<Empresa> GetEmpresa(string cnpj)
        {
            var endereco = $@"https://brasilapi.com.br/api/cnpj/v1/{cnpj}";
            var client = new HttpClient();

            try
            {

                HttpResponseMessage? response = client.GetAsync(endereco).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Status Code do Response : {(int)response.StatusCode} {response.ReasonPhrase}");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Empresa returnCnpj = JsonSerializer.Deserialize<Empresa>(responseBody);

                    return returnCnpj;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

namespace ApiRequest
{
    public class Empresa
    {
        public bool IsSuccessStatusCode { get; }
        public string uf { get; set; }
        public string cep { get; set; }
        public CnaesSecundario CnaesSecundario { get; set; }
        public Qsa Qsa { get; set; }
        public Root Root { get; set; }
        public string cnpj { get; set; }
        public object pais { get; set; }
        public object email { get; set; }
        public string porte { get; set; }
        public string bairro { get; set; }
        public string numero { get; set; }
        public string ddd_fax { get; set; }
        public string municipio { get; set; }
        public string logradouro { get; set; }
        public int cnae_fiscal { get; set; }
        public object codigo_pais { get; set; }
        public string complemento { get; set; }
        public int codigo_porte { get; set; }
        public string razao_social { get; set; }
        public string nome_fantasia { get; set; }
        //public int capital_social { get; set; }
        public string ddd_telefone_1 { get; set; }
        public string ddd_telefone_2 { get; set; }
        public object opcao_pelo_mei { get; set; }
        public string descricao_porte { get; set; }
        public int codigo_municipio { get; set; }
        public string natureza_juridica { get; set; }
        public string situacao_especial { get; set; }
        public object opcao_pelo_simples { get; set; }
        public int situacao_cadastral { get; set; }
        public object data_opcao_pelo_mei { get; set; }
        public object data_exclusao_do_mei { get; set; }
        public string cnae_fiscal_descricao { get; set; }
        public int codigo_municipio_ibge { get; set; }
        public string data_inicio_atividade { get; set; }
        public object data_situacao_especial { get; set; }
        public object data_opcao_pelo_simples { get; set; }
        public string data_situacao_cadastral { get; set; }
        public string nome_cidade_no_exterior { get; set; }
        public int codigo_natureza_juridica { get; set; }
        public object data_exclusao_do_simples { get; set; }
        public int motivo_situacao_cadastral { get; set; }
        public string ente_federativo_responsavel { get; set; }
        public int identificador_matriz_filial { get; set; }
        public int qualificacao_do_responsavel { get; set; }
        public string descricao_situacao_cadastral { get; set; }
        public string descricao_tipo_de_logradouro { get; set; }
        public string descricao_motivo_situacao_cadastral { get; set; }

        public string descricao_identificador_matriz_filial { get; set; }

    }
    public class CnaesSecundario
    {
        public int codigo { get; set; }
        public string descricao { get; set; }

        public CnaesSecundario(int codigo, string descricao)
        {
            this.codigo = codigo;
            this.descricao = descricao;
        }
    }

    public class Qsa
    {
        public int identificador_de_socio { get; set; }
        public string nome_socio { get; set; }
        public string cnpj_cpf_do_socio { get; set; }
        public int codigo_qualificacao_socio { get; set; }
        public int percentual_capital_social { get; set; }
        public string data_entrada_sociedade { get; set; }
        public object cpf_representante_legal { get; set; }
        public object nome_representante_legal { get; set; }
        public object codigo_qualificacao_representante_legal { get; set; }

        public Qsa(int identificador_de_socio, string nome_socio, string cnpj_cpf_do_socio, int codigo_qualificacao_socio, int percentual_capital_social, string data_entrada_sociedade, object cpf_representante_legal, object nome_representante_legal, object codigo_qualificacao_representante_legal)
        {
            this.identificador_de_socio = identificador_de_socio;
            this.nome_socio = nome_socio;
            this.cnpj_cpf_do_socio = cnpj_cpf_do_socio;
            this.codigo_qualificacao_socio = codigo_qualificacao_socio;
            this.percentual_capital_social = percentual_capital_social;
            this.data_entrada_sociedade = data_entrada_sociedade;
            this.cpf_representante_legal = cpf_representante_legal;
            this.nome_representante_legal = nome_representante_legal;
            this.codigo_qualificacao_representante_legal = codigo_qualificacao_representante_legal;
        }
    }

    public class Root
    {
        public string cnpj { get; set; }
        public int identificador_matriz_filial { get; set; }
        public string descricao_matriz_filial { get; set; }
        public string razao_social { get; set; }
        public string nome_fantasia { get; set; }
        public int situacao_cadastral { get; set; }
        public string descricao_situacao_cadastral { get; set; }
        public string data_situacao_cadastral { get; set; }
        public int motivo_situacao_cadastral { get; set; }
        public object nome_cidade_exterior { get; set; }
        public int codigo_natureza_juridica { get; set; }
        public string data_inicio_atividade { get; set; }
        public int cnae_fiscal { get; set; }
        public string cnae_fiscal_descricao { get; set; }
        public string descricao_tipo_de_logradouro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public int cep { get; set; }
        public string uf { get; set; }
        public int codigo_municipio { get; set; }
        public string municipio { get; set; }
        public string ddd_telefone_1 { get; set; }
        public object ddd_telefone_2 { get; set; }
        public object ddd_fax { get; set; }
        public int qualificacao_do_responsavel { get; set; }
        public int capital_social { get; set; }
        public int porte { get; set; }
        public string descricao_porte { get; set; }
        public bool opcao_pelo_simples { get; set; }
        public object data_opcao_pelo_simples { get; set; }
        public object data_exclusao_do_simples { get; set; }
        public bool opcao_pelo_mei { get; set; }
        public object situacao_especial { get; set; }
        public object data_situacao_especial { get; set; }
        public List<CnaesSecundario> cnaes_secundarios { get; set; }
        public List<Qsa> qsa { get; set; }

        public Root(
        string cnpj, int identificador_matriz_filial, string descricao_matriz_filial, string razao_social, string nome_fantasia, int situacao_cadastral, string descricao_situacao_cadastral,
        string data_situacao_cadastral, int motivo_situacao_cadastral, object nome_cidade_exterior, int codigo_natureza_juridica, string data_inicio_atividade, int cnae_fiscal,
        string cnae_fiscal_descricao, string descricao_tipo_de_logradouro, string logradouro, string numero, string complemento, string bairro, int cep, string uf, int codigo_municipio,
        string municipio, string ddd_telefone_1, object ddd_telefone_2, object ddd_fax, int qualificacao_do_responsavel, int capital_social, int porte, string descricao_porte,
        bool opcao_pelo_simples, object data_opcao_pelo_simples, object data_exclusao_do_simples, bool opcao_pelo_mei, object situacao_especial, object data_situacao_especial,
        List<CnaesSecundario> cnaes_secundarios, List<Qsa> qsa)
        {
            this.cnpj = cnpj;
            this.identificador_matriz_filial = identificador_matriz_filial;
            this.descricao_matriz_filial = descricao_matriz_filial;
            this.razao_social = razao_social;
            this.nome_fantasia = nome_fantasia;
            this.situacao_cadastral = situacao_cadastral;
            this.descricao_situacao_cadastral = descricao_situacao_cadastral;
            this.data_situacao_cadastral = data_situacao_cadastral;
            this.motivo_situacao_cadastral = motivo_situacao_cadastral;
            this.nome_cidade_exterior = nome_cidade_exterior;
            this.codigo_natureza_juridica = codigo_natureza_juridica;
            this.data_inicio_atividade = data_inicio_atividade;
            this.cnae_fiscal = cnae_fiscal;
            this.cnae_fiscal_descricao = cnae_fiscal_descricao;
            this.descricao_tipo_de_logradouro = descricao_tipo_de_logradouro;
            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = cep;
            this.uf = uf;
            this.codigo_municipio = codigo_municipio;
            this.municipio = municipio;
            this.ddd_telefone_1 = ddd_telefone_1;
            this.ddd_telefone_2 = ddd_telefone_2;
            this.ddd_fax = ddd_fax;
            this.qualificacao_do_responsavel = qualificacao_do_responsavel;
            this.capital_social = capital_social;
            this.porte = porte;
            this.descricao_porte = descricao_porte;
            this.opcao_pelo_simples = opcao_pelo_simples;
            this.data_opcao_pelo_simples = data_opcao_pelo_simples;
            this.data_exclusao_do_simples = data_exclusao_do_simples;
            this.opcao_pelo_mei = opcao_pelo_mei;
            this.situacao_especial = situacao_especial;
            this.data_situacao_especial = data_situacao_especial;
            this.cnaes_secundarios = cnaes_secundarios;
            this.qsa = qsa;
        }
    }
}