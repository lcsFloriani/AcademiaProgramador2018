export interface IAuthLastLoginData {
    isDealer: boolean;
    company: IAuthLoginData;
    dealer: IAuthLoginData;
}

export interface IAuthLoginData {
    dealer?: string,
    company: string;
    username: string;
}
