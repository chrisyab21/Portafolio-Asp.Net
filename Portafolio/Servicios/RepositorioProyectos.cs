using Portafolio.Interfaces;
using Portafolio.Models;

namespace Portafolio.Servicios
{
    public class RepositorioProyectos:IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {

            List<Proyecto> Lista1 = new List<Proyecto>(){

             new Proyecto(){  Titulo = "Amazon", Descripcion = "Malaso", ImagenUrl="/Imagenes/Amazon.jpg", Link="https://www.amazon.com/-/es/" },
             new Proyecto(){  Titulo = "New York Times", Descripcion = "Pagina de Noticias en React", ImagenUrl="/Imagenes/Nyt.jpg", Link="https://www.nytimes.com/" },
             new Proyecto(){  Titulo = "Reddit", Descripcion = "Red social para compartir informacion", ImagenUrl="/Imagenes/reddit.png", Link="https://www.reddit.com/" },
             new Proyecto(){  Titulo = "Steam", Descripcion = "Tienda online para comprar videojuegos", ImagenUrl="/Imagenes/Steam.jpeg", Link="https://store.steampowered.com/" },

         };

            return Lista1;

        }


    }
}
