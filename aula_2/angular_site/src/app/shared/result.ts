export class Result<T>{
    page?: number;
    qtd?: number;
    total?: number;
    totalPages?: number;
    data?: Array<T>;
}