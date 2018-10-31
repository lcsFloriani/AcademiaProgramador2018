/**
 * Dados do usuário autenticado.
 * Para usuário do tipo "parceiro", buscar dados no token.
 *
 * @export
 * @interface IAuthProfile
 */
export interface IAuthProfile {
    email: string;
    unique_name: string;
    userId: number;
}
