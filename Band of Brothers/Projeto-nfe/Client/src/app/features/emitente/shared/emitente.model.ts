export class Emitente {
    public id: number;
    public nome: string;
    public razaoSocial: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public localizacao: string;
}

export class EmitenteDeleteCommand {
    public emitenteIds: number[] = [];

    constructor(emitentes: Emitente[]) {
        this.emitenteIds = emitentes.map((c: Emitente) => c.id);
    }
}

export class EmitenteRegisterCommand {
    public nome: string;
    public razaoSocial: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public localizacao: string;
    constructor(emitente: Emitente) {
        this.nome = emitente.nome;
        this.razaoSocial = emitente.razaoSocial;
        this.cnpj = emitente.cnpj;
        this.inscricaoEstadual = emitente.inscricaoEstadual;
        this.localizacao = emitente.localizacao;
    }
}

export class EmitenteEditCommand {
    public id: number;
    public nome: string;
    public razaoSocial: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public localizacao: string;
    constructor(emitente: Emitente) {
        this.nome = emitente.nome;
        this.razaoSocial = emitente.razaoSocial;
        this.cnpj = emitente.cnpj;
        this.inscricaoEstadual = emitente.inscricaoEstadual;
        this.localizacao = emitente.localizacao;
    }
}
