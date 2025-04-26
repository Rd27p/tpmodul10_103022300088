using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_103022300088.Models;
namespace tpmodul10_103022300088.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Simulasi data statis (in-memory)
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Gusti Agung Raka Darma Putra Kepakisan", Nim = "103022300088" },
            new Mahasiswa { Nama = "Edsel Septa Haryanto", Nim = "103022300016" },
            new Mahasiswa { Nama = "Abdul Aziz Saepurohmat", Nim = "103022300092" },
            new Mahasiswa { Nama = "Deru Khairan Djuharianto", Nim = "103022300101" },
            new Mahasiswa { Nama = "Reza Indra Maulana", Nim = "103022300109" },
            new Mahasiswa { Nama = "Tio Funny Tinambunan", Nim = "103022330036" },
        };

        // GET: /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return Ok(mahasiswaList);
        }

        // GET: /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound("Data tidak ditemukan");

            return Ok(mahasiswaList[index]);
        }

        // POST: /api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            if (newMahasiswa == null || string.IsNullOrEmpty(newMahasiswa.Nama) || string.IsNullOrEmpty(newMahasiswa.Nim))
                return BadRequest("Data mahasiswa tidak valid");

            mahasiswaList.Add(newMahasiswa);
            return Ok(new { message = "Mahasiswa berhasil ditambahkan" });
        }

        // DELETE: /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound("Data tidak ditemukan");

            mahasiswaList.RemoveAt(index);
            return Ok(new { message = "Mahasiswa berhasil dihapus" });
        }
    }
}
