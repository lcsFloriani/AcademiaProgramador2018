// tslint:disable:no-bitwise
export enum RoleTypes {
    None = 0,
    User = 1,
    AdministratorRestrict = 2,
    AdministratorMaster = 4,
    Partner = 8,

    PartnerRestrict = User | Partner,
    PartnerAdministrator = AdministratorMaster | Partner,

    AdministratorsOnly = AdministratorRestrict | AdministratorMaster,
    Administrators = AdministratorRestrict | AdministratorMaster | PartnerAdministrator,

    InternalUsers = User | AdministratorsOnly,

    All = User | AdministratorRestrict | AdministratorMaster | Partner,

}
