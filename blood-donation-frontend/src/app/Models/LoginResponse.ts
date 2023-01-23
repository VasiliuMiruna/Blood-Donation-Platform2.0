import { User } from "./User";

export interface LoginResponse {
    isAuthSuccessful: boolean;
    errorMessage: string;
    token: string;
    user: User;
}