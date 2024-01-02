using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Security;
using Nop.Data;
using Nop.Services.Customers;
using System.Linq.Expressions;
using System.Reflection;

#nullable enable
namespace Nop.Plugin.InstantSearch.Services.Helpers
{
  public class AclHelper : IAclHelper
  {
    private readonly 
    #nullable disable
    IWorkContext _workContext;
    private readonly IRepository<AclRecord> _aclRepository;
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Manufacturer> _manufacturerRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly CatalogSettings _catalogSettings;
    private readonly ICustomerService _customerService;

    public AclHelper(
      IWorkContext workContext,
      IRepository<AclRecord> aclRepository,
      IRepository<Product> productRepository,
      IRepository<Manufacturer> manufacturerRepository,
      IRepository<Category> categoryRepository,
      CatalogSettings catalogSettings,
      ICustomerService customerService)
    {
      this._workContext = workContext;
      this._aclRepository = aclRepository;
      this._productRepository = productRepository;
      this._manufacturerRepository = manufacturerRepository;
      this._categoryRepository = categoryRepository;
      this._catalogSettings = catalogSettings;
      this._customerService = customerService;
    }

    //public async Task<IQueryable<Product>> GetAvailableProductsForCurrentCustomerAsync()
    //{        
    //    AclHelper.\u003C\u003Ec__DisplayClass8_0 cDisplayClass80 = new AclHelper.\u003C\u003Ec__DisplayClass8_0();
    //    ICustomerService icustomerService = this._customerService;
    //    int[] customerRoleIdsAsync = await icustomerService.GetCustomerRoleIdsAsync(await this._workContext.GetCurrentCustomerAsync(), false);
    //    icustomerService = (ICustomerService)null;
    //    // ISSUE: reference to a compiler-generated field
    //    cDisplayClass80.allowedCustomerRolesIds = customerRoleIdsAsync;
    //    IQueryable<Product> queryable = this._productRepository.Table.Select<Product, Product>((Expression<Func<Product, Product>>) (p => p));
    //  if (!this._catalogSettings.IgnoreAcl)
    //  {
    //    ParameterExpression parameterExpression1 = null;
    //    ParameterExpression parameterExpression2 = null;
    //    ParameterExpression parameterExpression3 = null;
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: field reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //            queryable = this._productRepository.Table.GroupJoin((IEnumerable<AclRecord>) this._aclRepository.Table, Expression.Lambda<Func<Product, int>>((Expression) Expression.Property((Expression) parameterExpression1, 
    //                nameof(BaseEntity.Id)), parameterExpression1), Expression.Lambda<Func<AclRecord, int>>((Expression) Expression.Property((Expression) parameterExpression2, 
    //                nameof(AclRecord.EntityId))), parameterExpression2), 
    //                (p, p_acl) => new
    //    {
    //      p = p,
    //      p_acl = p_acl
    //    }).SelectMany(data => data.p_acl.DefaultIfEmpty<AclRecord>(), (data, acl) => new
    //    {
    //      \u003C\u003Eh__TransparentIdentifier0 = data,
    //      acl = acl
    //    }).Where(Expression.Lambda<Func<AnonymousType<AnonymousType<Product, IEnumerable<AclRecord>>, AclRecord>, bool>>((Expression) Expression.OrElse((Expression) Expression.Not((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType6<Product, IEnumerable<AclRecord>>, AclRecord>.get_\u003C\u003Eh__TransparentIdentifier0), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType6<Product, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType6<Product, IEnumerable<AclRecord>>.get_p), __typeref (\u003C\u003Ef__AnonymousType6<Product, IEnumerable<AclRecord>>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Product.get_SubjectToAcl)))), (Expression) Expression.AndAlso((Expression) Expression.Equal((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType6<Product, IEnumerable<AclRecord>>, AclRecord>.get_acl), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType6<Product, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_EntityName))), (Expression) Expression.Constant((object) "Product", typeof (string))), (Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Enumerable.Contains)), new Expression[2]
    //    {
    //      (Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass80, typeof (AclHelper.\u003C\u003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle(__fieldref (AclHelper.\u003C\u003Ec__DisplayClass8_0.allowedCustomerRolesIds))),
    //      (Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType6<Product, IEnumerable<AclRecord>>, AclRecord>.get_acl), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType6<Product, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_CustomerRoleId)))
    //    }))), parameterExpression3)).Select(data => data.\u003C\u003Eh__TransparentIdentifier0.p);
      
    //  IQueryable<Product> currentCustomerAsync = queryable;
    //  cDisplayClass80 = (AclHelper.\u003C\u003Ec__DisplayClass8_0) null;
    //  return currentCustomerAsync;
    //}

    //public async Task<IQueryable<Manufacturer>> GetAvailableManufacturersForCurrentCustomerAsync()
    //{
    //  // ISSUE: object of a compiler-generated type is created
    //  // ISSUE: variable of a compiler-generated type
    //  AclHelper.\u003C\u003Ec__DisplayClass9_0 cDisplayClass90 = new AclHelper.\u003C\u003Ec__DisplayClass9_0();
    //  ICustomerService icustomerService = this._customerService;
    //  int[] customerRoleIdsAsync = await icustomerService.GetCustomerRoleIdsAsync(await this._workContext.GetCurrentCustomerAsync(), false);
    //  icustomerService = (ICustomerService) null;
    //  // ISSUE: reference to a compiler-generated field
    //  cDisplayClass90.allowedCustomerRolesIds = customerRoleIdsAsync;
    //  IQueryable<Manufacturer> queryable = this._manufacturerRepository.Table.Select<Manufacturer, Manufacturer>((Expression<Func<Manufacturer, Manufacturer>>) (m => m));
    //  if (!this._catalogSettings.IgnoreAcl)
    //  {
    //        ParameterExpression parameterExpression1 = null; ;
    //        ParameterExpression parameterExpression2 = null;
    //        ParameterExpression parameterExpression3 = null;
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: field reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    queryable = this._manufacturerRepository.Table.GroupJoin((IEnumerable<AclRecord>) this._aclRepository.Table, Expression.Lambda<Func<Manufacturer, int>>((Expression) Expression.Property((Expression) parameterExpression1, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (BaseEntity.get_Id))), parameterExpression1), Expression.Lambda<Func<AclRecord, int>>((Expression) Expression.Property((Expression) parameterExpression2, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_EntityId))), parameterExpression2), (m, m_acl) => new
    //    {
    //      m = m,
    //      m_acl = m_acl
    //    }).SelectMany(data => data.m_acl.DefaultIfEmpty<AclRecord>(), (data, acl) => new
    //    {
    //      \u003C\u003Eh__TransparentIdentifier0 = data,
    //      acl = acl
    //    }).Where(Expression.Lambda<Func<\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>, AclRecord>, bool>>((Expression) Expression.OrElse((Expression) Expression.Not((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>, AclRecord>.get_\u003C\u003Eh__TransparentIdentifier0), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>.get_m), __typeref (\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Manufacturer.get_SubjectToAcl)))), (Expression) Expression.AndAlso((Expression) Expression.Equal((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>, AclRecord>.get_acl), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_EntityName))), (Expression) Expression.Constant((object) "Manufacturer", typeof (string))), (Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Enumerable.Contains)), new Expression[2]
    //    {
    //      (Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass90, typeof (AclHelper.\u003C\u003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle(__fieldref (AclHelper.\u003C\u003Ec__DisplayClass9_0.allowedCustomerRolesIds))),
    //      (Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>, AclRecord>.get_acl), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType14<Manufacturer, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_CustomerRoleId)))
    //    }))), parameterExpression3)).Select(data => data.\u003C\u003Eh__TransparentIdentifier0.m);
      
    //  IQueryable<Manufacturer> currentCustomerAsync = queryable;
    //  cDisplayClass90 = (AclHelper.\u003C\u003Ec__DisplayClass9_0) null;
    //  return currentCustomerAsync;
    //}

    //public async Task<IQueryable<Category>> GetAvailableCategoriesForCurrentCustomerAsync()
    //{
    //  // ISSUE: object of a compiler-generated type is created
    //  // ISSUE: variable of a compiler-generated type
    //  AclHelper.\u003C\u003Ec__DisplayClass10_0 cDisplayClass100 = new AclHelper.\u003C\u003Ec__DisplayClass10_0();
    //  ICustomerService icustomerService = this._customerService;
    //  int[] customerRoleIdsAsync = await icustomerService.GetCustomerRoleIdsAsync(await this._workContext.GetCurrentCustomerAsync(), false);
    //  icustomerService = (ICustomerService) null;
    //  // ISSUE: reference to a compiler-generated field
    //  cDisplayClass100.allowedCustomerRolesIds = customerRoleIdsAsync;
    //  IQueryable<Category> queryable = this._categoryRepository.Table.Select<Category, Category>((Expression<Func<Category, Category>>) (c => c));
    //  if (!this._catalogSettings.IgnoreAcl)
    //  {
    //    ParameterExpression parameterExpression1;
    //    ParameterExpression parameterExpression2;
    //    ParameterExpression parameterExpression3;
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    // ISSUE: method reference
    //    // ISSUE: field reference
    //    // ISSUE: method reference
    //    // ISSUE: type reference
    //    // ISSUE: method reference
    //    queryable = this._categoryRepository.Table.GroupJoin((IEnumerable<AclRecord>) this._aclRepository.Table, Expression.Lambda<Func<Category, int>>((Expression) Expression.Property((Expression) parameterExpression1, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (BaseEntity.get_Id))), parameterExpression1), Expression.Lambda<Func<AclRecord, int>>((Expression) Expression.Property((Expression) parameterExpression2, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_EntityId))), parameterExpression2), (c, c_acl) => new
    //    {
    //      c = c,
    //      c_acl = c_acl
    //    }).SelectMany(data => data.c_acl.DefaultIfEmpty<AclRecord>(), (data, acl) => new
    //    {
    //      \u003C\u003Eh__TransparentIdentifier0 = data,
    //      acl = acl
    //    }).Where(Expression.Lambda<Func<\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>, bool>>((Expression) Expression.OrElse((Expression) Expression.Not((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>.get_\u003C\u003Eh__TransparentIdentifier0), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>.get_c), __typeref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Category.get_SubjectToAcl)))), (Expression) Expression.AndAlso((Expression) Expression.Equal((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>.get_acl), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_EntityName))), (Expression) Expression.Constant((object) "Category", typeof (string))), (Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Enumerable.Contains)), new Expression[2]
    //    {
    //      (Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass100, typeof (AclHelper.\u003C\u003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle(__fieldref (AclHelper.\u003C\u003Ec__DisplayClass10_0.allowedCustomerRolesIds))),
    //      (Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression3, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>.get_acl), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_CustomerRoleId)))
    //    }))), parameterExpression3)).Select(data => data.\u003C\u003Eh__TransparentIdentifier0.c);
      
    //  IQueryable<Category> currentCustomerAsync = queryable;
    //  cDisplayClass100 = (AclHelper.\u003C\u003Ec__DisplayClass10_0) null;
    //  return currentCustomerAsync;
    //}

    public async Task<string> GetAllowedCustomerRolesIdsAsync()
    {
        ICustomerService icustomerService = this._customerService;
        int[] customerRoleIdsAsync = await icustomerService.GetCustomerRoleIdsAsync(await this._workContext.GetCurrentCustomerAsync(), false);
        icustomerService = (ICustomerService)null;
        return string.Join<int>(",", (IEnumerable<int>)customerRoleIdsAsync);
    }

        public Task<IQueryable<Category>> GetAvailableCategoriesForCurrentCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Manufacturer>> GetAvailableManufacturersForCurrentCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Product>> GetAvailableProductsForCurrentCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<int, int>> GetCategoryAndParentCategoryIdsForCurrentCustomerAsync()
        {
            throw new NotImplementedException();
        }
        //    public async Task<Dictionary<int, int>> GetCategoryAndParentCategoryIdsForCurrentCustomerAsync()
        //{
        //  // ISSUE: object of a compiler-generated type is created
        //  // ISSUE: variable of a compiler-generated type
        //  AclHelper cDisplayClass110 = new AclHelper.\u003C\u003Ec__DisplayClass11_0();
        //  ICustomerService icustomerService = this._customerService;
        //  int[] customerRoleIdsAsync = await icustomerService.GetCustomerRoleIdsAsync(await this._workContext.GetCurrentCustomerAsync(), false);
        //  icustomerService = (ICustomerService) null;
        //  // ISSUE: reference to a compiler-generated field
        //  cDisplayClass110.allowedCustomerRolesIds = customerRoleIdsAsync;
        //  ParameterExpression parameterExpression1;
        //  // ISSUE: method reference
        //  // ISSUE: type reference
        //  // ISSUE: method reference
        //  // ISSUE: method reference
        //  // ISSUE: method reference
        //  // ISSUE: type reference
        //  // ISSUE: method reference
        //  // ISSUE: type reference
        //  IQueryable<\u003C\u003Ef__AnonymousType0<int, int>> source = this._categoryRepository.Table.Select(Expression.Lambda<Func<Category, \u003C\u003Ef__AnonymousType0<int, int>>>((Expression)
        //      Expression.New((ConstructorInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType0<int, int>.\u002Ector), __typeref (\u003C\u003Ef__AnonymousType0<int, int>)), (IEnumerable<Expression>) new Expression[2]
        //  {
        //     Expression.Property( parameterExpression1,nameof(BaseEntity.Id))),
        //     Expression.Property( parameterExpression1, nameof (Category.ParentCategoryId)))
        //  }, nameof(\u003C\u003Ef__AnonymousType0<int, int>.CategoryId), __typeref (\u003C\u003Ef__AnonymousType0<int, int>)),
        //  (MemberInfo) nameof(\u003C\u003Ef__AnonymousType0<int, int>.ParentCategoryId), __typeref (\u003C\u003Ef__AnonymousType0<int, int>))), parameterExpression1));
        //  if (!this._catalogSettings.IgnoreAcl)
        //        {
        //            ParameterExpression parameterExpression2 = null;

        //            ParameterExpression parameterExpression3 = null;
        //            ParameterExpression parameterExpression4 = null;
        //            ParameterExpression parameterExpression5 = null;

        //            source = this._categoryRepository.Table.GroupJoin((IEnumerable<AclRecord>) this._aclRepository.Table, Expression.Lambda<Func<Category, int>>((Expression) Expression.Property((Expression) parameterExpression2, 
        //            nameof(BaseEntity.Id))), parameterExpression2), Expression.Lambda<Func<AclRecord, int>>((Expression) Expression.Property((Expression) parameterExpression3, 
        //            nameof(AclRecord.EntityId))), parameterExpression3), (c, c_acl) => new
        //    {
        //      c = c,
        //      c_acl = c_acl
        //    }).SelectMany(data => data.c_acl.DefaultIfEmpty<AclRecord>(), (data, acl) => new
        //    {
        //      \u003C\u003Eh__TransparentIdentifier0 = data,
        //      acl = acl
        //    }).Where(Expression.Lambda<Func<\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>, bool>>((Expression) Expression.OrElse((Expression) Expression.AndAlso((Expression) Expression.GreaterThan((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression4, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>.get_\u003C\u003Eh__TransparentIdentifier0), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>.get_c), __typeref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Category.get_ParentCategoryId))), (Expression) Expression.Constant((object) 0, typeof (int))), (Expression) Expression.Not((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression4, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>.get_\u003C\u003Eh__TransparentIdentifier0), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>.get_c), __typeref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Category.get_SubjectToAcl))))), (Expression) Expression.AndAlso((Expression) Expression.Equal((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression4, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>.get_acl), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_EntityName))), (Expression) Expression.Constant((object) "Category", typeof (string))), (Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Enumerable.Contains)), new Expression[2]
        //    {
        //      (Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass110, typeof (AclHelper.\u003C\u003Ec__DisplayClass11_0)), 
        //    FieldInfo.GetFieldFromHandle(__fieldref (AclHelper.\u003C\u003Ec__DisplayClass11_0.allowedCustomerRolesIds))),
        //      (Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression4, 
        //    (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, 
        //    IEnumerable<AclRecord>>, AclRecord>.get_acl), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, 
        //    IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AclRecord.get_CustomerRoleId)))
        //    }))), parameterExpression4)).Select(Expression.Lambda<Func<\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, 
        //    IEnumerable<AclRecord>>, AclRecord>, \u003C\u003Ef__AnonymousType0<int, int>>>((Expression) Expression.New((ConstructorInfo)
        //    MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType0<int, int>.\u002Ector), __typeref (\u003C\u003Ef__AnonymousType0<int, int>)), (IEnumerable<Expression>) new Expression[2]
        //    {
        //      (Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression5, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>.get_\u003C\u003Eh__TransparentIdentifier0), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>.get_c), __typeref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (BaseEntity.get_Id))),
        //      (Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) parameterExpression5, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>.get_\u003C\u003Eh__TransparentIdentifier0), __typeref (\u003C\u003Ef__AnonymousType8<\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>, AclRecord>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>.get_c), __typeref (\u003C\u003Ef__AnonymousType15<Category, IEnumerable<AclRecord>>))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Category.get_ParentCategoryId)))
        //    }, (MemberInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType0<int, int>.get_categoryId), __typeref (\u003C\u003Ef__AnonymousType0<int, int>)), (MemberInfo) MethodBase.GetMethodFromHandle(__methodref (\u003C\u003Ef__AnonymousType0<int, int>.get_parentCategoryId), __typeref (\u003C\u003Ef__AnonymousType0<int, int>))), parameterExpression5));

        //  List<\u003C\u003Ef__AnonymousType0<int, int>> list = source.ToList();
        //  Dictionary<int, int> dictionary = new Dictionary<int, int>();
        //      foreach (var data in list)
        //      {
        //            if (!dictionary.ContainsKey(data.categoryId))
        //              dictionary.Add(data.categoryId, data.parentCategoryId);
        //          }
        //    }
        //  Dictionary<int, int> currentCustomerAsync = dictionary;
        //  cDisplayClass110 = (AclHelper.\u003C\u003Ec__DisplayClass11_0) null;
        //  return currentCustomerAsync;
        //}


    }
}
