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

			CreateMap<UpdatePasswordRequestDto, UpdatePasswordCommand>()
				.ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => EncryptAES(src.Password)));

			CreateMap<CreatePasswordRequestDto, CreatePasswordCommand>()
			.ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => EncryptAES(src.Password))); 

			CreateMap<IEnumerable<Password>, GetAllPasswordResponseDto>()
	.ForMember(dest => dest.Passwords, opt => opt.MapFrom(src => src));
		}

		private static string EncryptAES(string plainText)
		{
			if (string.IsNullOrEmpty(plainText))
				return string.Empty;

			return AESHelper.Encrypt(plainText);
		}

	}
}
