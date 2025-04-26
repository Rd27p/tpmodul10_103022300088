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
            new Mahasiswa { Nama = "LeBron James", Nim = "1302000001" },
            new Mahasiswa { Nama = "Stephen Curry", Nim = "1302000002" }
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
