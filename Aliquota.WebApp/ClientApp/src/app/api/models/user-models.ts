export interface UserModel {
    email: string;
    fullName: string;
}

export interface AuthenticationResponse {
    success: boolean;
    token: string;
    user: UserModel;
}