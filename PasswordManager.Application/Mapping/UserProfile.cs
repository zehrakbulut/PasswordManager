using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PasswordManager.Application.Dtos.Requests.User;
using PasswordManager.Application.Dtos.Responses.User;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Application.Helpers;
using PasswordManager.Domain.Models.Tables;

namespace PasswordManager.Application.Mapping
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<CreateUserRequestDto, CreateUserCommand>()
				.ForMember(dest => dest.HashedMasterPassword, opt => opt.MapFrom(src => PasswordHasher.HashPassword(src.Password)));

			CreateMap<User, GetUserByIdResponseDto>();

			CreateMap<UpdateUserRequestDto, UpdateUserCommand>()
				.ForMember(dest => dest.HashedMasterPassword, opt => opt.MapFrom(src => src.Password != null ? PasswordHasher.HashPassword(src.Password) : null));

			CreateMap<IEnumerable<User>, GetAllUsersResponseDto>()
				.ForMember(dest => dest.Users, opt => opt.MapFrom(src => src));
		}
	}
}