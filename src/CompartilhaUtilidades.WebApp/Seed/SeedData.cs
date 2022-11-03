using CompartilhaUtilidades.Data;
using CompartilhaUtilidades.Model.Dtos;
using CompartilhaUtilidades.Model.Entities;
using System;
using System.Linq;

namespace CompartilhaUtilidades.WebApp.Seed
{
    public class SeedData
    {
        protected SeedData()
        {
        }

        public static void Initialize(IServiceProvider serviceProvider, ApplicationContext context)
        {
            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(entity: new Usuario(
                new UsuarioDto
                {
                    Nome = "Administrador",
                    Login = "admin",
                    Senha ="123456",
                    DataDeNascimento = DateTime.Now,
                    Sexo = Model.Enumeradores.SexoEnum.Masculino,
                    Email = "cleitonjust@yahoo.com.br",
                    Contato = new ContatoTelefoneDto { TelefoneCelular = "41984848484", TelefoneFixo="4545454545",TelefoneRecado ="454545454"},
                    Endereco = new EnderecoDto { Bairro ="a", Cep="45454545",Cidade="Curitiba",Estado="Pr", Numero =1,Logradouro ="Rua", TipoResidencia= Model.Enumeradores.TipoResidenciaEnum.Apartamento}
                }));

                context.SaveChanges();
            }

        }
    }
}
