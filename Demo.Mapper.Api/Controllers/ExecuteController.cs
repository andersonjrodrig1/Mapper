using Demo.Mapper.Api.Entities;
using Demo.Mapper.Api.Interfaces;
using Demo.Mapper.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Demo.Mapper.Api.Controllers
{
    [ApiController]
    public class ExecuteController : ControllerBase
    {

        [HttpGet]
        [Route("execute")]
        public void GetExecute([FromServices] IClientService services)
        {
            Console.WriteLine("\n******* Execute mapping of Client ************\n");
            Console.WriteLine("-------------- Mapper to Client ------------------");

            var client = services.ExecuteMapperToClient(new ClientViewModel
            {
                Cod_Client = 1,
                First_Name = "João da Silva",
                Last_Name = "Sauro",
                Birth_Date = DateTime.Parse("1985-10-15"),
                Gender_Name = "Masculino"
            });

            Console.WriteLine(JsonConvert.SerializeObject(client));
            Console.WriteLine("\n-------------- Mapper to ClientViewModel ------------------");

            var viewModel = services.ExecuteMapperToClientViewModel(new Client
            {
                Id = 1,
                FirstName = "Maria da Silva",
                LastName = "Sauro",
                BirthDate = DateTime.Parse("1985-10-15"),
                Gender = new Gender
                {
                    Descrition = "Feminino"
                }
            });

            Console.WriteLine(JsonConvert.SerializeObject(viewModel));
            Console.WriteLine("\n-------------- Mapper List ------------------");

            var clients = services.ExecuteMapperList(new List<ClientViewModel>
            {
                new ClientViewModel
                {
                    Cod_Client = 1,
                    First_Name = "João da Silva",
                    Last_Name = "Sauro",
                    Birth_Date = DateTime.Parse("1985-10-15"),
                    Gender_Name = "Masculino"
                },
                new ClientViewModel
                {
                    Cod_Client = 1,
                    First_Name = "Maria da Silva",
                    Last_Name = "Sauro",
                    Birth_Date = DateTime.Parse("1985-10-15"),
                    Gender_Name = "Feminino"
                }
            });

            Console.WriteLine(JsonConvert.SerializeObject(clients));
        }
    }
}
