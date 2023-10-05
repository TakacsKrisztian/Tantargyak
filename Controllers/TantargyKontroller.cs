using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using Tantargyak.Modell;

namespace Tantargyak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TantargyKontroller : ControllerBase
    {
        Csatlakozas csatlakozas = new();
        private readonly List<TantargyDto> tantargyak = new();

        [HttpGet]
        public ActionResult<IEnumerable<TantargyDto>> Get()
        {

            try
            {
                csatlakozas.connection.Open();
                string esquel = "SELECT * FROM ertekelesek";

                MySqlCommand cmd = new MySqlCommand(esquel, csatlakozas.connection);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var eredmeny = new TantargyDto(
                        reader.GetGuid("Azon"),
                        reader.GetInt32("Jegy"),
                        reader.GetString("Leiras"),
                        reader.GetString("Letrejott")
                        );
                    tantargyak.Add(eredmeny);
                }

                csatlakozas.connection.Close();

                return StatusCode(200, tantargyak);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]

        public ActionResult<TantargyDto> Post(TantargyLetrehozasDto tantargyLetrehozas)
        {
            string ido = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var tantargy = new Tantargy
            {
                Azon = Guid.NewGuid(),
                Jegy = tantargyLetrehozas.Jegy,
                Leiras = tantargyLetrehozas.Leiras,
                Letrejott = ido,
            };

            try
            {
                csatlakozas.connection.Open();
                string esquel = $"INSERT INTO `ertekelesek`(`Azon`, `Jegy`, `Leiras`,`Letrejott`) VALUES ('{tantargy.Azon}','{tantargy.Jegy}','{tantargy.Leiras}','{tantargy.Letrejott}')";
                MySqlCommand céemdé = new MySqlCommand(esquel, csatlakozas.connection);
                céemdé.ExecuteNonQuery();
                csatlakozas.connection.Close();
                return StatusCode(201, tantargy);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{azon}")]

            public ActionResult<TantargyDto> Get(Guid azon)
            {
                csatlakozas.connection.Open();
                string esquel = "SELECT * FROM ertekelesek WHERE Azon = @Azon";
                MySqlCommand céemdé = new MySqlCommand(esquel, csatlakozas.connection);
                céemdé.Parameters.AddWithValue("Azon", azon);
                MySqlDataReader reader = céemdé.ExecuteReader();
                if (reader.Read())
                {
                    var eredmeny = new TantargyDto(
                        reader.GetGuid("Azon"),
                        reader.GetInt32("Jegy"),
                        reader.GetString("Leiras"),
                        reader.GetString("Letrejott")
                        );
                    csatlakozas.connection.Close();
                    return StatusCode(200, eredmeny);
                }
                else
                {
                    Exception e = new();
                    csatlakozas.connection.Close();
                    return StatusCode(404, e);
                }
            }

            [HttpPut("{azon}")]

            public ActionResult<TantargyDto> Put(TantargyValtozasDto tantargyValtozas, Guid azon)
            {
                DateTime datumIdo = DateTime.Now;
                string ido = datumIdo.ToString("yyyy-MM-dd HH:mm:ss");

                try
                {
                    csatlakozas.connection.Open();

                    string esquel = $"UPDATE `ertekelesek` SET `Jegy`=@Jegy,`Leiras`=@Leiras WHERE Azon = @Azon";
                    MySqlCommand céemdé = new MySqlCommand(esquel, csatlakozas.connection);

                    céemdé.Parameters.AddWithValue("Jegy", tantargyValtozas.Jegy);
                    céemdé.Parameters.AddWithValue("Leiras", tantargyValtozas.Leiras);
                    céemdé.Parameters.AddWithValue("Azon", azon);

                céemdé.ExecuteNonQuery();
                    return StatusCode(200);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{azon}")]

            public ActionResult<TantargyDto> Delete(TantargyTorlesDto tantargyTorles, Guid azon)
            {
                DateTime datumIdo = DateTime.Now;
                string ido = datumIdo.ToString("yyyy-MM-dd HH:mm:ss");

                try
                {
                    csatlakozas.connection.Open();

                    string esquel = $"DELETE FROM ertekelesek WHERE Azon = @Azon";
                    MySqlCommand céemdé = new MySqlCommand(esquel, csatlakozas.connection);

                    céemdé.Parameters.AddWithValue("Azon", azon);
                    céemdé.ExecuteNonQuery();

                    csatlakozas.connection.Close();
                    return StatusCode(200);
                }
                catch (Exception)
                {
                    return StatusCode(404, "Nincs tartalom.");
                }
            }
        }
    }