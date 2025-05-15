import { useState } from 'react';
import Input from '../../components/Common/Input/Input';
import AuthButton from '../../components/Common/AuthButton/AuthButton';
import { ForgotPassword } from '../../services/api/AuthApiService';
import './ForgotPassword.scss';

const ForgotPasswordPage = () => {
  const [email, setEmail] = useState('');
  const [loading,setLoading]=useState(false);
  const [message,setMessage]=useState('');

  const handleSubmit = async(e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setMessage('');


    try{
      await ForgotPassword({email});
      setMessage("Check your email for a reset link");
      
    }
    catch(error:any){
      setMessage("An error occured.Please try again");
    }
    finally{
      setLoading(false);
    }
  };

  return (
    <div className="forgot-password-background-image">
      <div className="header">
        <h1>Forgot Password?</h1>
        <p>No problem! Enter your email address and we'll send you an update link.</p>

        <form onSubmit={handleSubmit}>
          <Input
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Email"
            name="email"
          />
          <AuthButton content={loading ? 'Sending...' : 'Send'} disabled={loading || !email}/>
        </form>
      </div>
    </div>
  );
};

export default ForgotPasswordPage;
