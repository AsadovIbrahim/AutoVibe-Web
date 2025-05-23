export type PasswordProps={
    placeholder:string;
    value:string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    name:string;
}