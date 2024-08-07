using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using SOAPDemo;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TelecommunicationWebApp.DataAccess;
using TelecommunicationWebApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelecommunicationWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private readonly TelecommunicationContext _context;

        public InitialDataController(TelecommunicationContext context)
        {
            _context = context;
        }

        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {
            // Getting data from SOAP and importing/mapping it into database
            SOAPDemo.SOAPDemoSoapClient SoapClient = new SOAPDemo.SOAPDemoSoapClient();
            int iterator = 1;
            bool run = true;

            // Colors
            HashSet<string> colors = new HashSet<string>();
            while (run)
            {
                Task<Person> person = SoapClient.FindPersonAsync(iterator.ToString());
                person.Wait();
                if (person.Result != null && person.Result.FavoriteColors != null)
                {
                    foreach (var color in person.Result.FavoriteColors)
                    {
                        colors.Add(color);
                    }
                }
                if (person.Result == null) run = false;
                iterator++;
            }

            foreach (var color in colors)
            {
                _context.Colors.Add(new Color { Name = color });
            }

            iterator = 1;
            run = true;

            // States
            HashSet<string> states = new HashSet<string>();
            while (run)
            {
                Task<Person> person = SoapClient.FindPersonAsync(iterator.ToString());
                person.Wait();
                if (person.Result != null && person.Result.Home.State != null && person.Result.Office.State != null)
                {
                    states.Add(person.Result.Home.State);
                    states.Add(person.Result.Office.State);
                }
                if (person.Result == null) run = false;
                iterator++;
            }

            foreach (var state in states)
            {
                _context.States.Add(new State { Name = state });
            }

            iterator = 1;
            run = true;

            // Cities
            HashSet<string> cities = new HashSet<string>();
            while (run)
            {
                Task<Person> person = SoapClient.FindPersonAsync(iterator.ToString());
                person.Wait();
                if (person.Result != null && person.Result.Home.City != null && person.Result.Office.City != null)
                {
                    cities.Add(person.Result.Home.City);
                    cities.Add(person.Result.Office.City);
                }
                if (person.Result == null) run = false;
                iterator++;
            }

            foreach (var city in cities)
            {
                _context.Cities.Add(new City { Name = city });
            }

            iterator = 1;
            run = true;
            _context.SaveChanges();

            // Addresses and Users
            List<SOAPDemo.Employee> employees = new List<SOAPDemo.Employee>();
            while (run)
            {
                Task<Person> person = SoapClient.FindPersonAsync(iterator.ToString());
                person.Wait();
                if (person.Result != null)
                {
                    //Console.WriteLine("Id: " + iterator);
                    //Console.WriteLine("Fullname: " + person.Result.Name);
                    //Console.WriteLine("Email: " + ConvertToEmail(person.Result.Name));
                    //Console.WriteLine("Password: " + BCrypt.Net.BCrypt.HashPassword("Password1"));
                    //Console.WriteLine("SSN: " + person.Result.SSN);
                    //Console.WriteLine("DOB: " + person.Result.DOB);
                    //Console.WriteLine("Home State Id: " + _context.States.Where(x => x.Name == person.Result.Home.State).FirstOrDefault().Id);
                    //Console.WriteLine("Home City Id: " + _context.Cities.Where(x => x.Name == person.Result.Home.City).FirstOrDefault().Id);
                    //Console.WriteLine("Office State Id: " + _context.States.Where(x => x.Name == person.Result.Office.State).FirstOrDefault().Id);
                    //Console.WriteLine("Office City Id: " + _context.Cities.Where(x => x.Name == person.Result.Office.City).FirstOrDefault().Id);
                    //Console.WriteLine("Spouse Id: " + (person.Result.Spouse != null ? _context.Users.Where(x => x.Fullname == person.Result.Spouse.Name)
                    //                                                                 .Select(x => x.Id)
                    //                                                                 .FirstOrDefault() : null));
                    //Console.WriteLine("Age: " + (int)person.Result.Age);
                    //Console.WriteLine("-------------------------------------");

                    User newUser = new User
                    {
                        Fullname = person.Result.Name,
                        Email = ConvertToEmail(person.Result.Name),
                        Password = BCrypt.Net.BCrypt.HashPassword("Password1"),
                        SocialSecurityNumber = person.Result.SSN,
                        DateOfBirth = person.Result.DOB,
                        Home = new Domain.Address
                        {
                            Street = person.Result.Home.Street,
                            State = _context.States.Where(x => x.Name == person.Result.Home.State).FirstOrDefault(),
                            City = _context.Cities.Where(x => x.Name == person.Result.Home.City).FirstOrDefault(),
                            Zip = person.Result.Home.Zip
                        },
                        Office = new Domain.Address
                        {
                            Street = person.Result.Office.Street,
                            State = _context.States.Where(x => x.Name == person.Result.Office.State).FirstOrDefault(),
                            City = _context.Cities.Where(x => x.Name == person.Result.Office.City).FirstOrDefault(),
                            Zip = person.Result.Office.Zip
                        },
                        SpouseId = (person.Result.Spouse != null ? _context.Users.Where(x => x.Fullname == person.Result.Spouse.Name)
                                                                                 .Select(x => x.Id)
                                                                                 .FirstOrDefault() : null),
                        Age = (int)person.Result.Age,
                        UseCases = { }
                    };

                    _context.Users.Add(newUser);
                    _context.SaveChanges();


                    if (person.Result is SOAPDemo.Employee employee)
                    {
                        //Console.WriteLine("Employee ID: " + newUser.Id);
                        //Console.WriteLine("Employee title: " + employee.Title);
                        //Console.WriteLine("Employee salary: " + employee.Salary);
                        //Console.WriteLine("-------------------------");
                        employees.Add(employee);
                    }

                    //if (person.Result.FavoriteColors != null)
                    //{
                    //    for (int i = 0; i < person.Result.FavoriteColors.Length; i++)
                    //    {
                    //        UserColor userColor = new UserColor
                    //        {
                    //            User = newUser,
                    //            Color = _context.Colors.Where(c => c.Name == person.Result.FavoriteColors[i]).FirstOrDefault()
                    //        };

                    //        _context.UsersColors.Add(userColor);
                    //    }

                    //    _context.SaveChanges();
                    //}
                }
                else run = false;
                iterator++;
            }

            // Employees
            foreach (var employee in employees)
            {
                Domain.Employee newEmployee = new Domain.Employee
                {
                    UserId = _context.Users.Where(x => x.Fullname == employee.Name).FirstOrDefault().Id,
                    Title = employee.Title,
                    Salary = employee.Salary,
                    Notes = employee.Notes
                };

                _context.Employees.Add(newEmployee);
            }

            _context.SaveChanges();

            // Services
            Service service1 = new Service
            {
                Name = "Mobile service #1",
                Description = "Sample mobile service description",
                Price = 100m
            };
            Service service2 = new Service
            {
                Name = "Internet service #2",
                Description = "Sample internet service description",
                Price = 200m
            };
            Service service3 = new Service
            {
                Name = "TV service #3",
                Description = "Sample TV service description",
                Price = 300m
            };

            _context.Services.AddRange(service1, service2, service3);
            _context.SaveChanges();

            // Use Cases

            UserUseCase userUseCase = new UserUseCase
            {
                UseCaseId = 1,
                UserId = 101
            };

            _context.UserUseCases.Add(userUseCase);
            _context.SaveChanges();

            string ConvertToEmail(string name)
            {
                string conversion = "";

                if (name.IsNullOrEmpty()) return string.Empty;

                conversion = name.Replace(".", "")
                                 .Replace(" ", "")
                                 .Replace(",", "")
                                 .ToLower();

                conversion += "@gmail.com";

                return conversion;
            }

            return Ok("Data was successfully mapped to database.");
        }
    }
}
