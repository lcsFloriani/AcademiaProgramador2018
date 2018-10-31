using NDDResearch.API.Controllers.Common;
using NDDResearch.API.Filters;
using NDDResearch.Application.Features.Customers;
using NDDResearch.Application.Features.Customers.Commands;
using NDDResearch.Application.Features.Customers.Queries;
using NDDResearch.Application.Features.Sites;
using NDDResearch.Application.Features.Sites.Queries;
using NDDResearch.Domain.Features.Customers;
using NDDResearch.Domain.Features.Sites;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;


namespace NDDResearch.API.Controllers.Customers
{
    /// <summary>
    /// Controlador de Customers
    /// 
    /// Essa classe é responsável por prover os dados relacionados a entidade Customer.
    /// 
    /// Perceba que não há obrigatóriedade de que os seus metódos precisem retornar sempre o tipo Customer 
    /// assim, todos os métodos aqui presente que estão relacionados a essa entidade,
    ///
    /// Por exemplo, o GET {customerId:int}/sites retorna uma lista de Sites mas a pesquisa é pelo customerId
    /// logo está nesse CustomerController e não no SitesController.
    /// 
    /// </summary>
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiControllerBase
    {
        private readonly ICustomersService _customersService;
        private readonly ISitesService _sitesService;

        // Usamos IoC aqui para injetar a instância única (singleton) nesse controller
        public CustomersController(ICustomersService customersService, ISitesService sitesService) : base()
        {
            _customersService = customersService;
            _sitesService = sitesService;
        }

        #region HttpGet
        /// <summary>
        /// Interface para obter um customer específico pelo id
        /// </summary>
        /// <param name="customerId">É o id do customer para realizar a pesquisa. Provém diretamente da url pela configuração do Route</param>
        /// <returns>Retorna o customer com id correspondente ao paramêtro customerId</returns>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(_customersService.GetById(id));
        }

        /// <summary>
        /// Interface para obter uma lista geral de customers
        /// </summary>
        /// <param name="queryOptions">São os parâmetros relacionados ao odata. Provém do framework.</param>
        /// <returns>Retorna uma lista de customers de acordo com as configurações definidas em queryOptions</returns>
        [ODataQueryOptionsValidate]
        [HttpGet]
        public IHttpActionResult Get(ODataQueryOptions<Customer> queryOptions)
        {
            var query = _customersService.GetAll();

            return HandleQuery<Customer, CustomerQuery>(query, queryOptions);
        }

        /// <summary>
        /// Retorna os sites de um customer
        /// </summary>
        /// <param name="customerId">É o id do customer para realizar a pesquisa. Provém diretamente da url pela configuração do Route</param>
        /// <param name="queryOptions">São os parâmetros relacionados ao odata. Provém do framework.</param>
        /// <returns>Retorna uma lista de sites que estão relacionados ao customerId</returns>
        [ODataQueryOptionsValidate]
        [HttpGet]
        [Route("{customerId:int}/sites")]
        public IHttpActionResult Get(int customerId, ODataQueryOptions<Site> queryOptions)
        {
            var query = _sitesService.GetAll(customerId);

            return HandleQuery<Site, SiteQuery>(query, queryOptions);
        }

        #endregion HttpGet

        #region HttpPost
        /// <summary>
        /// Interface para cadastro de customers
        /// </summary>
        /// <param name="customerCmd">É o customer que será cadastrado no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpPost]
        public IHttpActionResult Post(CustomerRegisterCommand customerCmd)
        {
            var validator = customerCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_customersService.Add(customerCmd));
        }

        #endregion HttpPost

        #region HttpPut
        /// <summary>
        /// Interface para editar um customer
        /// </summary>
        /// <param name="command">É o customer que será atualizado no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpPut]
        public IHttpActionResult Update(CustomerUpdateCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_customersService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// Interface para remover um customer
        /// </summary>
        /// <param name="command">É o customer que será removido no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpDelete]
        public IHttpActionResult Remove(CustomerRemoveCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_customersService.Remove(command));
        }

        #endregion HttpDelete
    }
}