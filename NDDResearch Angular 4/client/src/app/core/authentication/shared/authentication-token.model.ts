/**
 * JSON Web Token de autenticação.
 *
 * @export
 * @interface IAuthToken
 */
export interface IAuthToken {
    Dealer: string;
    DealerId: string;
    UserId: string;
    aud: string;
    email: string;
    exp: number;
    iss: string;
    nbf: number;
    role: string;
    unique_name: string;
    // Unknown
    acct: string;
    rol: string;
}
