using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog;

/// <summary>
/// Represents a category model
/// </summary>
[NopModelResourceDisplayName(localizationPrefix: "Admin.Catalog.Categories.Fields.")]
public partial record CategoryModel : BaseNopEntityModel, IAclSupportedModel, IDiscountSupportedModel,
    ILocalizedModel<CategoryLocalizedModel>, IStoreMappingSupportedModel
{
    #region Ctor

    public CategoryModel()
    {
        if (PageSize < 1)
        {
            PageSize = 5;
        }

        Locales = new List<CategoryLocalizedModel>();
        AvailableCategoryTemplates = new List<SelectListItem>();
        AvailableCategories = new List<SelectListItem>();
        AvailableDiscounts = new List<SelectListItem>();
        SelectedDiscountIds = new List<int>();

        SelectedCustomerRoleIds = new List<int>();
        AvailableCustomerRoles = new List<SelectListItem>();

        SelectedStoreIds = new List<int>();
        AvailableStores = new List<SelectListItem>();

        CategoryProductSearchModel = new CategoryProductSearchModel();
    }

    #endregion

    #region Properties

    public string Name { get; set; }

    public string Description { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.CategoryTemplate")]
    public int CategoryTemplateId { get; set; }
    public IList<SelectListItem> AvailableCategoryTemplates { get; set; }

    public string MetaKeywords { get; set; }

    public string MetaDescription { get; set; }

    public string MetaTitle { get; set; }

    public string SeName { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.Parent")]
    public int ParentCategoryId { get; set; }

    [UIHint("Picture")]
    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.Picture")]
    public int PictureId { get; set; }

    public int PageSize { get; set; }

    public bool AllowCustomersToSelectPageSize { get; set; }

    public string PageSizeOptions { get; set; }

    public bool PriceRangeFiltering { get; set; }

    public decimal PriceFrom { get; set; }

    public decimal PriceTo { get; set; }

    public bool ManuallyPriceRange { get; set; }

    public bool ShowOnHomepage { get; set; }

    public bool IncludeInTopMenu { get; set; }

    public bool Published { get; set; }

    public bool Deleted { get; set; }

    public int DisplayOrder { get; set; }

    public IList<CategoryLocalizedModel> Locales { get; set; }

    public string Breadcrumb { get; set; }

    //ACL (customer roles)
    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.AclCustomerRoles")]
    public IList<int> SelectedCustomerRoleIds { get; set; }
    public IList<SelectListItem> AvailableCustomerRoles { get; set; }

    //store mapping
    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.LimitedToStores")]
    public IList<int> SelectedStoreIds { get; set; }
    public IList<SelectListItem> AvailableStores { get; set; }

    public IList<SelectListItem> AvailableCategories { get; set; }

    //discounts
    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.Discounts")]
    public IList<int> SelectedDiscountIds { get; set; }
    public IList<SelectListItem> AvailableDiscounts { get; set; }

    public CategoryProductSearchModel CategoryProductSearchModel { get; set; }

    public string PrimaryStoreCurrencyCode { get; set; }

    #endregion
}

public partial record CategoryLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.Description")]
    public string Description { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.MetaKeywords")]
    public string MetaKeywords { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.MetaDescription")]
    public string MetaDescription { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.MetaTitle")]
    public string MetaTitle { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.SeName")]
    public string SeName { get; set; }
}