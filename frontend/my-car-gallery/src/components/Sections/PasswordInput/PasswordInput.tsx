import { PasswordProps } from '../../../types/InputProps';
import './PasswordInput.scss';

const PasswordInput = ({ placeholder, value, onChange, name }: PasswordProps) => {
  return (
    <div className="password-input">
      <input
        type="password"
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        name={name} 
      />
    </div>
  );
};

export default PasswordInput;
