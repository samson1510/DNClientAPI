using System;
using System.Collections.Generic;
using System.Text;

namespace DataNova.Common {
  public enum DNPaymentType {
    Undefined,
    Cash,
    Bank,
    Credit,
    GiftVoucher,
    IOU,
    Smartcard,
    Cheque,
    Order,
    Other,
    BottleReturn,
    Invoice,
    MCash,
    MobilePay,
    Vipps,
    PIMBank,
    XPAYOUT,
    OfflineBank,
    Alibaba,
    ReturnPanel,
    PayEx
  };
  public enum DiscountType {
    Campaign,
    PickMix,
    ConnectedItem,
    MixMatch,
    Matrix,
    CodeDiscount,
    Menu,
    Manual,
    Subtotal,
    Dun,
    Step,
    BuyMPayN,
    BuyMPayAmount,
    DiscountGroup,
    Employee,
    Customer,
    MemberShip,
    CampaignGroup,
    CampaignSupplierGroup,
    CampaignItemGroup,
    Category,
    CustomerPerItem,
    MemberOffer,
    MatrixWithoutCustomer,
    MemeberOfferWithoutCustomer,
    Club,
    Loyalty,
    LgPickAndMix,
    ScannedMenuPack,
    Coupon,
    CampaignandMatrix,
    CustomerDeal
  }
  public enum ReceiptDiscountType { Manual, Matrix, Campaign, Subtotal, Dun, Step, BuyMPayN, BuyMPayAmount, DiscountGroup, Employee, Customer, MemberShip, CampaignGroup, CampaignSupplierGroup, CampaignItemGroup, Connected, Category, CustomerPerItem, PickAndMix, MemberOffer, MatrixWithoutCustomer, MemeberOfferWithoutCustomer, MenuItem, Club, Loyalty, LgPickAndMix, ScannedMenuPack, Coupon, CampaignandMatrix, CustomerDeal, MixMatch };
  public enum DNDashboardType { MobileST, MobileTicket, MobileLoyalty, PickOrders, MobileTicketValidation, MobileCanteen, WebERP, WebShop, KPI }
  public enum DNAppType { Operator, Customer }
  public enum DNPageType { None, TicketPurchaseContentPage1, TicketPurchaseContentPage2, Login, Dashboard, MyProfile, MyLoyality, Saldo, MyOrders, Discount, Loyality, Receipt, ContactUs, PaymentOptions, Logout, PrintReceiptOptions, EditPassword, EditMobile, PickOrders, GoodsAdjustment, GoodsReceipt, GoodsPlacement, Checklogerstatus, ShopsNearUser, Customer, Items, TextToSpeech, Feedback, Help, About, PriceCheck, Budget, Referral, StockCounting, StockCount, DeviceSettings, Signup, CanteenDashboard, AddBalance, DiscountPage, LoyaltyPage, Events, EventDetail, ItemSearchPage, CustomDashboard }
  public enum DNControlType { CoverFlowView, BarCodeImage, None, TabbedPage, Page, Entry, Editor, Picker, DatePicker, Button, Image, Label, LinkLabel, AnimationView, Keyboard, QRCode, StackLayout, ImageButton, DNCustomButton, DNStackLayout, Frame, BoxView, SearchBar, List, DNListView, DNNumericUpDown }
  public enum FastKeyType {
    ITEM,
    ITEMGROUP,
    CUSTOMER,
    PANEL,
    MENUITEM,
    DUNCODE,
    LOGICALGROUP,
    ITEMSERIES,
    SUBSCRIPTION
  }
  public enum DNControlAlignment { None, Left, Center, Right, Fill }
  public enum DNControlSize { Full, Half }
  public enum DNThemeType { Light, Dark, Custom }
  public enum OrderLineStatus { NONE, SCANNEDVALID, SCANNEDINVALID, INPROGRESS, DELIVERED, INPROGRESSVISITED }

  public enum DNGoodsReceiptStatus {
    NotProcessed = 0,
    PartlyProcessed = 1,
    PerfectMatch = 2,
    DeliveredOverload = 3,
    NotInOrder = 4
  }
  public enum DNWidgetType { NONE, FastKey, WidgetButton, PaymentButton, Discount, Loyalty, Graphs, Saldo, TodaySales, DateTime, DNControl, SearchShop }
  public enum DNCommandType {
    NONE, SEARCHRECEIPT, REPRINT, CANCELSALE, REMOVESELECTEDLINE, CUSTOMERSEARCH, ITEMSEARCH, HENT, ITEMDETAILS, PRICECHECK, PANT, ZREPORT, XREPORT, RECEIPTFREETEXT, LOGOUT, CHANGEQUANTITY, REPEATLINE, BUDGET, TEXTTOSPEECH, SYNCHRONIZE,
    OPENCASHDRAWER, EDITSETTINGS, BANKREVERSAL, BANKRETURN, RETURN, CASHDECLARATION, CREATEGIFTVOUCHER, RETURNMODE, FINDSHOP, VIEWLOYALTY, VIEWDISCOUNTS, MOSTBOUGHTITEMS, VIEWSALDO, BUYMEALS, BUYTICKET, PAYIN, HENTORDER, WASTEREGISTERED, PAYOUT, CHANGEVAT, RETURNPAYMEAN, ADMINSEASONCARD, PAYBYSMARTCARD, REKLAMASJONRETURNER, ANSATTPRIS, STUDENTPRIS, SHIFTEND, PLURAPPORT, INGRIDIENT, BETALMEDOPPVALUERINGSKORT
  }
  public enum DNSpeechCommandType {
    NONE, SEARCHRECEIPT, REPRINT, CANCELSALE, REMOVESELECTEDLINE, CUSTOMERSEARCH, ITEMSEARCH, HENT, ITEMDETAILS, PRICECHECK, PANT, ZREPORT, XREPORT, RECEIPTFREETEXT, LOGOUT, CHANGEQUANTITY, REPEATLINE, BUDGET, TEXTTOSPEECH, SYNCHRONIZE,
    OPENCASHDRAWER, EDITSETTINGS, BANKREVERSAL, BANKRETURN, PAYMENTOPTIONS, FASTKEY
  }
  public enum ReceiptPrinterCommands {
    NormalSizeString, BigSizeString, NormalFontString, BoldFontString, UnderlineFontStringOn, UnderlineFontStringOff,
    ReverseFontStringColourOn, ReverseFontStringColourOff, BarCodeWithNumberString, BarCodeforPluString,
    LogoString, CutString, JournalEnableString, JournalDisableString, NationalString, SlipString, DrawerOpenString,
    EANCodeString, LeftJustifyString, RightJustifyString, CentreJustifyString, TranslateString, NewLine, MediumSizeString,
    NewFontString
  }
  public enum ReceiptType {
    NONE, SALES, GOODS, PAYIN, PAYOT, CASHD, CANCL, WASTE, STOCK, XPAYIN, XPAYOT, ORDER, BANK, HOORDER, MIFARE, ATTD, GVIOU, LABEL, StockTransfer, SendOrdreTilHK, CardTransaction, ExpensePayout, ExpensePayin, CompanyDiscountReceipt, RETURPANT,
  }
  public enum LineEntityType { item, itemgroup, giftvoucher, duncode, serial, payin, payout, All, RentOut, RentIn, MenuPack, BottleReturn, labelItem, QRCodeCustomer, TSN, PlayerNo, Itemseries, Subscription }
  public enum PrintingResult {
    Success,
    UnknownError,
    GetPortError,
    BeginCheckedBlockError,
    EndCheckedBlockError,
    GetParsedStatusError,
    WritePortError,
  }
  public enum LineType {
    OneLine, TwoLine, ThreeLine, LongItemName, FourLine, FiveLine, SupplierItemNoSize
  }
  public enum PrintFormatting {
    FontInverseColour = 0x001, FontUnderLine = 0x010, FontBold = 0x100
  }
  public enum PrintFont {
    FontNormal, FontLarge
  }
  public enum PrintAlignment {
    AlignLeft, AlignCenter, AlignRight
  }
  public enum PrintCharacterSet {
    USA, France, Germany, UK, Denmark, Sweden, Japan, Norway
  }
  public enum EntitiesToBePrinted {
    Text4
  }
  public enum ReceiptPrinterPaperSize { MM_80, MM_58 }
  public enum ReceiptprinterLanguage { ENG, NOR, SWE, DAN, GER, FIN }
  public enum DNBudgetLevel { Day, Week, Month, Hour }
  public enum DNBudgetState { Under0 = 0, Till25, Till50, Till75, Till100, Over100 }

  public enum DNBankTransactionType { PURCHASE, RETURN, REVERSAL }

  public enum DNItemType {
    Blank,
    ElectricalItemExcGuarantee,
    ElectricalItemIncGuarantee,
    GoldSmith,
    Liquor,
    Renting,
    Z,
    Recipe,
    Tobbaco,
    EnergyDrinks,
    Tile,
    Telekort,
    MoneyGame,
    Commission,
    Medicine,
    Food,
    ColdStorage,
    Frozen,
    ShoppingBag,
    AlcoholFree,
    SpilliKassa,
    StoreSales,
    CinemaTickets,
    Badekort,
    Paintball,
    Gebyr
  }

  public enum DNCommissionType { Blank, PayIn, PayOut }
  public enum DNLanguageType {
    /// <summary>
    /// Blank
    /// </summary>
    Blank = -1,
    Norwegian_Bokmal = 0,
    English = 1,
    Swedish = 2,
    Danish = 3,
    German = 4,
    Finnish = 5,

  }
  public enum DNTopDiscountSortBy {
    Amount,
    Date
  }

  public enum DNOrientationType {
    All,
    Portrait,
    Landscape
  }

  public enum UserType {
    boss,
    guide,
    staff,
    Operator
  }

  public enum NotificationType {
    error,
    success,
    warning,
    info
  }

  public enum DNCustomerCreditType {
    Normal,
    Credit,
    Internal,
    Utmeldt
  };
  public enum DNCustomerSexType {
    Male,
    Female
  };
  public enum DNCustomerType {

    /// <summary>
    /// Blank
    /// </summary>
    ///   
    organisation,
    Private,
    Patner,
    blanknotext
  };
  public enum DNInvoiceDeliveryType {
    Print,
    Email,
    //Efaktura,
    AvtaleGiro,
    FinInvoice,
    EHF,
    Autogiro,
    Remmitance,
    B2CEHF
  };

  public enum DNCustimerLoginType {
    Mobile,
    Email
  };
  public enum PushNotificationMessageType { NONE, Setting, Layout, Receipt }
  public enum SortType { None, Ascending, Descending }
  public enum DNDeviceType { BankTerminal, ReceiptPrinter, Scanner }
  public enum ReceiptPrinterType { NONE, MOBILE, mPOP }
  public enum PCLServiceState {
    PCL_SERVICE_STOPPED = 0,
    PCL_SERVICE_STARTED = 1,
    PCL_SERVICE_CONNECTED = 2,
    PCL_SERVICE_FAILED_NO_CNX = 3,
    PCL_SERVICE_FAILED_INTERNAL = 4
  }
  public enum GiftVocherType {
    Paper, SmartCard, XponCard, None, MiFare, BankCard
  }

  public enum DNActionCommand {
    New,
    Delete,
    Save,
    DeleteLine,
    Show,
    Back,
    Copy,
    savetimeinfo,
    Refresh,
    SaveAdditionalDetails,
    AddBlankRow,
    sendEmail,
    process,
    Publish,
    Apply,
    Navigate,
    Get,
    Load,
    CopyWeak
  }

  public enum DNMultiseekType {
    Item,
    ItemGroup,
    VatRate,
    Supplier,
    Department,
    Region,
    PinCode,
    PayMean,
    BottleReturn,
    Profile,
    Judical,
    CustomerCategory,
    Account,
    SeasonCards,
    Tickets,
    Duncode,
    LogicalGroup,
    Operator,
    Customer,
    Shop,
    Terminal,
    InvoicePayment,
    CustomerGroup,
    Location,
    PurchaseOrderFiletered,
    Invoice,
    InvoiceVoucher,
    Municipality,
    TimeRestrictionGroup,
    PayMeansFlag,
    PayMeanForeignCurrency,
    BedriftsColumnFilter
  }

  public enum DNGalleryType {
    Item,
    CMS
  }
  public enum DNCustomerIdentity {

    /// <summary>
    /// Cash
    /// </summary>
    Cash,

    /// <summary>
    /// Credit
    /// </summary>
    Credit,

    /// <summary>
    /// Requisition
    /// </summary>
    Requisition,

    /// <summary>
    /// Subsidy
    /// </summary>
    Subsidy,

    /// <summary>
    /// Debit
    /// </summary>
    Debit
  }
  public enum InvoiceDeliveryType {
    Print,
    Email,
    //EFaktura,
    AvtaleGiro,
    FinInvoice,
    EHF,
    Autogiro,
    Remmitance,
    B2CEHF
  };
  public enum WebPaymentType {
    VIPPS, NETS, PAYEX, ADMIN, NONE
  }
  //public enum ShopType{
  //   2-Shop,4-test, ADMIN
  //}
  public enum WebResponseType { NONE, ERROR, SUCCESS };
  public enum DNLoyaltyEntityType { Item, Itemgroup };
  public enum DNWebPayStatus { NONE, BEGUN, SUCCESS, ERROR, CANCEL }

  public enum WebDataGridOperator { CONTAINS, EQUAL, LESSTHAN, GREATERTHAN, LESSTHANOREQUAL, GREATERTHANOREQUAL, STARTSWITH, ENDSWITH, BETWEEN, NOTEQUAL }
  public enum UserProfileType { Boss = 0, Salesman = 1 } //, Cashier = 2, Staff = 3, Guide = 4 

  public enum DNNotificationTemplateType { MAIL, SMS, PUSH };
  public enum DNSourceType { WebShop };
  public enum DNWebErrorCode { BadRequest = 400, PageNotFound = 404, InternalServerError = 500, GatewayTimeout = 501 }
  public enum DNStaticLinkPageType { ContactUs, AboutUs, HelpAndFAQ, TermsAndConditions, PrivacyPolicy }
  public enum ERPTurnOverType { SalesWoVat, SalesWVat }

  public enum DNLogicalGroupCategory { Default, Membership, Entrance }
  public enum DNCashDeclarationType { Operator, Shop, Terminal }

  public enum DNBookingItemType { Item, Duncode }

  public enum DNRpiModuleType { RestaurantClient, RestaurantServer, WebBrowser, Dashboard }

  /// <summary>
  /// Control Check 
  /// </summary>
  public enum DNControlCheck { None, Age, Energy, Medicine }

  public enum DNFontSize { None, MicroFontSize, SmallFontSize, RegularFontSize, MediumFontSize, LargeFontSize }

  public enum DNWebBlockType { Link, Information }

  public enum DNCashDrawerState { OPEN, CLOSED, ERROR }

  public enum DiscountTypeFromAPI {
    Campaign,
    PickMix,
    ConnectedItem,
    MixMatch,
    Matrix,
    CodeDiscount
  }

  public enum DNSign { GreaterThan, Lessthan, Equalto }

  public enum DNSpaceType { Auditorium, Retaurant }

  public enum DNWebShopComponentType {
    NONE,
    BANNERS,
    EVENTLIST,
    CART,
    EVENTDETAILS,
    FEEDS,
    FILTER,
    FOOTER,
    HEADER,
    HIGHLIGHTS,
    INTRODUCTION,
    ITEMDETAILS,
    ITEMS,
    PARTNERS,
    PAYMENT,
    PAYMENTCOMPLETE,
    ROOMS,
    SEATS,
    UPCOMINGEVENTS,
    WEBBLOCK,
    LANGUAGESELECT,
    USERIDENTIFICATION,
    MENU,
    TITLETEXT
  }
  public enum DNWebShopPageType {
    DASHBOARD,
    DETAILS,
    PAYMENT,
    USERIDENTIFICATION,
    PAYMENTCOMPLETE,
    CART,
    PARTNERLIST,
    EVENTLIST,
    ROOMSLIST,
    SEATSELECTION
  }
  public enum GroupStatus {
    Free = 0,
    Booked = 1,
    Reserved = 2,
    Maintenance = 3,
    AutoAllocated = 4,
    OrderCreated = 5,
    OrderComplete = 6,
    FoodDelivered = 7,
    CheckedIn = 8,
    Temporary = 9
  }

  public enum AttributeTypeFromAPI {
    Color = 1,
    Size,
    Model,
    SizeGroup
  }
}
