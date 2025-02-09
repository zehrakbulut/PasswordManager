using AutoMapper;
using PasswordManager.Application.Dtos.Requests.Password;
using PasswordManager.Application.Dtos.Requests.User;
using PasswordManager.Application.Dtos.Responses.Password;
using PasswordManager.Application.Dtos.Responses.User;
using PasswordManager.Application.Features.PasswordFeature.Commands;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Mapping
{
	public class PasswordProfile : Profile
	{
		public PasswordProfile()
		{
			CreateMap<Password, GetPasswordByIdResponseDto>();

			CreateMap<Password, GetPasswordByIdResponseDto>(); // Liste içindeki her User için tekil map

			CreateMap<UpdatePasswordRequestDto, UpdatePasswordCommand>();

			CreateMap<IEnumerable<Password>, GetAllPasswordResponseDto>()
	.ForMember(dest => dest.Passwords, opt => opt.MapFrom(src => src));
		}
	}
}
