using System.Web;
using System.Web.Mvc;

namespace ProjetoFinalWeb
{
    /// <summary>
    ///Utilizado para registrar os filtros globais do MVC. Esses filtros são aplicados a todas as Actions e Controllers.
    ///Fornecem uma técnica simples e poderosa de modificar ou melhorar o pipeline do ASP.Net MVC através da “injeção” de comportamento 
    ///em determinados momentos ajudando a resolver diversas situações em algumas ou todas as partes da aplicação.
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
