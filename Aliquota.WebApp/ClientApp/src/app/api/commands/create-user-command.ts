export interface CreateUserCommand {
    email: string;
    fullName: string;
    password: string;
}

export interface LoginCommand {
    email: string;
    password: string;
}