using autenticacao.Data.Dtos;
using autenticacao.Models;
using AutoMapper;

namespace autenticacao.Profiles
{
    public class UsuarioProfile : Profile
    {

        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
