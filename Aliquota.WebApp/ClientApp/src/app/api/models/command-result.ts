export interface CommandResult<T> {
    success: boolean;
    message: string;
    data?: T;
}