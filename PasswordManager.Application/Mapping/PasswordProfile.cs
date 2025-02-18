using AutoMapper;
using PasswordManager.Application.Dtos.Requests.Password;
using PasswordManager.Application.Dtos.Responses.Password;
using PasswordManager.Application.Features.PasswordFeature.Commands;
using PasswordManager.Application.Helpers;
using PasswordManager.Domain.Models.Tables;

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