using AutoMapper;
using PasswordManager.Application.Dtos.Requests.User;
using PasswordManager.Application.Dtos.Responses.User;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Mapping
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<CreateUserRequestDto, CreateUserCommand>()
	.ForMember(dest => dest.HashedMasterPassword, opt => opt.MapFrom(src => src.Password));

			CreateMap<User, GetUserByIdResponseDto>();

			CreateMap<User, GetUserByIdResponseDto>(); // Liste içindeki her User için tekil map

			CreateMap<UpdateUserRequestDto, UpdateUserCommand>();

			CreateMap<IEnumerable<User>, GetAllUsersResponseDto>()
	.ForMember(dest => dest.Users, opt => opt.MapFrom(src => src));
		}
	}
}
