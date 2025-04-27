import { InputProps } from '../../../types/InputProps';
import './Input.scss';

const Input = ({ placeholder, value, onChange, name }: InputProps) => {
  return (
    <div className="input-border">
      <input
        type="text"
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        name={name} 
      />
    </div>
  );
};

export default Input;
