using ApiRequestWs;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using MainProg;


namespace ApiRequestWs
{

    public class DadosEmpresaWs
    {
        public static async Task<Empresa> GetEmpresa(string cnpj)
        {
            var endereco = $@"https://publica.cnpj.ws/cnpj/{cnpj}";
            var client = new HttpClient();


            HttpResponseMessage? response = client.GetAsync(endereco).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Empresa returnCnpj = JsonSerializer.Deserialize<Empresa>(responseBody);

            return returnCnpj;



        }
    }



    public class Empresa
    {
        public string cnpj_raiz { get; set; }
        public string razao_social { get; set; }
        public string capital_social { get; set; }
        public string responsavel_federativa { get; set; }
        public string atualizado_em { get; set; }

        public Porte Porte { get; set; }
        public NaturezaJuridica Juridica { get; set; }
        public QualificacaoDoResponsavel QualificacaoDoResponsavel { get; set; }
        public Socios Socios { get; set; }
        public string simples { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public Pais Pais { get; set; }
        public Estado Estado { get; set; }
        public Cidade Cidade { get; set; }
        public string motivo_situacao_cadastral { get; set; }
        public string inscricoes_estaduais { get; set; }


    }
    public class AtividadePrincipal
    {
        public string id { get; set; }
        public string secao { get; set; }
        public string divisao { get; set; }
        public string grupo { get; set; }
        public string classe { get; set; }
        public string subclasse { get; set; }
        public string descricao { get; set; }

        public AtividadePrincipal(string id, string secao, string divisao, string grupo, string classe, string subclasse, string descricao)
        {
            this.id = id;
            this.secao = secao;
            this.divisao = divisao;
            this.grupo = grupo;
            this.classe = classe;
            this.subclasse = subclasse;
            this.descricao = descricao;
        }
    }


    public class AtividadesSecundaria
    {
        public string id { get; set; }
        public string secao { get; set; }
        public string divisao { get; set; }
        public string grupo { get; set; }
        public string classe { get; set; }
        public string subclasse { get; set; }
        public string descricao { get; set; }

        public AtividadesSecundaria(string id, string secao, string divisao, string grupo, string classe, string subclasse, string descricao)
        {
            this.id = id;
            this.secao = secao;
            this.divisao = divisao;
            this.grupo = grupo;
            this.classe = classe;
            this.subclasse = subclasse;
            this.descricao = descricao;
        }
    }

    public class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int ibge_id { get; set; }
        public string siafi_id { get; set; }

        public Cidade(int id, string nome, int ibge_id, string siafi_id)
        {
            this.id = id;
            this.nome = nome;
            this.ibge_id = ibge_id;
            this.siafi_id = siafi_id;
        }
    }

    public class Estabelecimento
    {
        public string cnpj { get; set; }
        public List<AtividadesSecundaria> atividades_secundarias { get; set; }
        public string cnpj_raiz { get; set; }
        public string cnpj_ordem { get; set; }
        public string cnpj_digito_verificador { get; set; }
        public string tipo { get; set; }
        public string nome_fantasia { get; set; }
        public string situacao_cadastral { get; set; }
        public string data_situacao_cadastral { get; set; }
        public string data_inicio_atividade { get; set; }
        public object nome_cidade_exterior { get; set; }
        public string tipo_logradouro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string ddd1 { get; set; }
        public string telefone1 { get; set; }
        public object ddd2 { get; set; }
        public object telefone2 { get; set; }
        public object ddd_fax { get; set; }
        public object fax { get; set; }
        public string email { get; set; }
        public object situacao_especial { get; set; }
        public object data_situacao_especial { get; set; }
        public DateTime atualizado_em { get; set; }
        public AtividadePrincipal atividade_principal { get; set; }
        public Pais pais { get; set; }
        public Estado estado { get; set; }
        public Cidade cidade { get; set; }
        public object motivo_situacao_cadastral { get; set; }
        public List<object> inscricoes_estaduais { get; set; }

        public Estabelecimento(string cnpj, List<AtividadesSecundaria> atividades_secundarias, string cnpj_raiz, string cnpj_ordem, string cnpj_digito_verificador, string tipo, string nome_fantasia, string situacao_cadastral, string data_situacao_cadastral, string data_inicio_atividade, object nome_cidade_exterior, string tipo_logradouro, string logradouro, string numero, string complemento, string bairro, string cep, string ddd1, string telefone1, object ddd2, object telefone2, object ddd_fax, object fax, string email, object situacao_especial, object data_situacao_especial, DateTime atualizado_em, AtividadePrincipal atividade_principal, Pais pais, Estado estado, Cidade cidade, object motivo_situacao_cadastral, List<object> inscricoes_estaduais)
        {
            this.cnpj = cnpj;
            this.atividades_secundarias = atividades_secundarias;
            this.cnpj_raiz = cnpj_raiz;
            this.cnpj_ordem = cnpj_ordem;
            this.cnpj_digito_verificador = cnpj_digito_verificador;
            this.tipo = tipo;
            this.nome_fantasia = nome_fantasia;
            this.situacao_cadastral = situacao_cadastral;
            this.data_situacao_cadastral = data_situacao_cadastral;
            this.data_inicio_atividade = data_inicio_atividade;
            this.nome_cidade_exterior = nome_cidade_exterior;
            this.tipo_logradouro = tipo_logradouro;
            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = cep;
            this.ddd1 = ddd1;
            this.telefone1 = telefone1;
            this.ddd2 = ddd2;
            this.telefone2 = telefone2;
            this.ddd_fax = ddd_fax;
            this.fax = fax;
            this.email = email;
            this.situacao_especial = situacao_especial;
            this.data_situacao_especial = data_situacao_especial;
            this.atualizado_em = atualizado_em;
            this.atividade_principal = atividade_principal;
            this.pais = pais;
            this.estado = estado;
            this.cidade = cidade;
            this.motivo_situacao_cadastral = motivo_situacao_cadastral;
            this.inscricoes_estaduais = inscricoes_estaduais;
        }
    }

    public class Estado
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public int ibge_id { get; set; }
        public Estado(int id, string nome, string sigla, int ibge_id)
        {
            this.id = id;
            this.nome = nome;
            this.sigla = sigla;
            this.ibge_id = ibge_id;
        }
    }

    public class NaturezaJuridica
    {
        public string id { get; set; }
        public string descricao { get; set; }

        public NaturezaJuridica(string id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }
    }

    public class Pais
    {
        public string id { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public string nome { get; set; }
        public string comex_id { get; set; }

        public Pais(string id, string iso2, string iso3, string nome, string comex_id)
        {
            this.id = id;
            this.iso2 = iso2;
            this.iso3 = iso3;
            this.nome = nome;
            this.comex_id = comex_id;
        }
    }

    public class Porte
    {
        public string id { get; set; }
        public string descricao { get; set; }

        public Porte(string id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }
    }

    public class QualificacaoDoResponsavel
    {
        public int id { get; set; }
        public string descricao { get; set; }

        public QualificacaoDoResponsavel(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }
    }

    public class QualificacaoSocio
    {
        public int id { get; set; }
        public string descricao { get; set; }

        public QualificacaoSocio(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }
    }

    public class Root
    {
        public string cnpj_raiz { get; set; }
        public string razao_social { get; set; }
        public string capital_social { get; set; }
        public string responsavel_federativo { get; set; }
        public DateTime atualizado_em { get; set; }
        public Porte porte { get; set; }
        public NaturezaJuridica natureza_juridica { get; set; }
        public QualificacaoDoResponsavel qualificacao_do_responsavel { get; set; }
        public List<Socios> socios { get; set; }
        public object simples { get; set; }
        public Estabelecimento estabelecimento { get; set; }

        public Root(string cnpj_raiz, string razao_social, string capital_social, string responsavel_federativo, DateTime atualizado_em, Porte porte, NaturezaJuridica natureza_juridica, QualificacaoDoResponsavel qualificacao_do_responsavel, List<Socios> socios, object simples, Estabelecimento estabelecimento)
        {
            this.cnpj_raiz = cnpj_raiz;
            this.razao_social = razao_social;
            this.capital_social = capital_social;
            this.responsavel_federativo = responsavel_federativo;
            this.atualizado_em = atualizado_em;
            this.porte = porte;
            this.natureza_juridica = natureza_juridica;
            this.qualificacao_do_responsavel = qualificacao_do_responsavel;
            this.socios = socios;
            this.simples = simples;
            this.estabelecimento = estabelecimento;
        }
    }

    public class Socios
    {
        public string cpf_cnpj_socio { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public string data_entrada { get; set; }
        public string cpf_representante_legal { get; set; }
        public object nome_representante { get; set; }
        public string faixa_etaria { get; set; }
        public DateTime atualizado_em { get; set; }
        public string pais_id { get; set; }
        public QualificacaoSocio qualificacao_socio { get; set; }
        public object qualificacao_representante { get; set; }
        public Pais pais { get; set; }

        public Socios(string cpf_cnpj_socio, string nome, string tipo, string data_entrada, string cpf_representante_legal, object nome_representante, string faixa_etaria, DateTime atualizado_em, string pais_id, QualificacaoSocio qualificacao_socio, object qualificacao_representante, Pais pais)
        {
            this.cpf_cnpj_socio = cpf_cnpj_socio;
            this.nome = nome;
            this.tipo = tipo;
            this.data_entrada = data_entrada;
            this.cpf_representante_legal = cpf_representante_legal;
            this.nome_representante = nome_representante;
            this.faixa_etaria = faixa_etaria;
            this.atualizado_em = atualizado_em;
            this.pais_id = pais_id;
            this.qualificacao_socio = qualificacao_socio;
            this.qualificacao_representante = qualificacao_representante;
            this.pais = pais;
        }
    }
}

