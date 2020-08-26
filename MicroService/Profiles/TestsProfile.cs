using AutoMapper;
using Models.Dtos.Tests;
using Models.Models;

namespace MicroService.Profiles
{
	public class TestsProfile : Profile
	{
		public TestsProfile()
		{
			// arg 1 from, arg 2 To
			// source -> target
			CreateMap<Test, TestReadDto>();
		}
	}
}
