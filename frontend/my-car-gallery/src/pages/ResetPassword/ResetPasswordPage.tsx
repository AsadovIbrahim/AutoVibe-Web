import './ResetPasswordPage.scss'
import { ResetPassword } from '../../services/api/AuthApiService'
import { useSearchParams,useNavigate } from 'react-router-dom'
import { useState } from 'react';
import PasswordInput from '../../components/Sections/PasswordInput/PasswordInput';
import AuthButton from '../../components/Common/AuthButton/AuthButton';


const ResetPasswordPage=()=>{

    const [searchParams]=useSearchParams();
    const token=searchParams.get("token");
    const [password,setPassword]=useState('');
    const [confirmPassword,setConfirmPassword]=useState('');
    const [message, setMessage] = useState('');
    const [loading, setLoading] = useState(false);
    const navigate=useNavigate();


    const handleSubmit=async(e:React.FormEvent)=>{
        e.preventDefault();
        setLoading(true);
        setMessage('');

        if(password!=confirmPassword){
            setMessage('Passwords do not match!');
            setLoading(false);
            return;
        }
        try{
            await ResetPassword(token!, {
              password: password,
              confirmPassword: confirmPassword
            });

            setMessage('Password has been successfully reset!');
            setTimeout(() => navigate('/login'), 2000);
        }catch(error:any){
            setMessage('Failed to reset password.Try again');
        }finally{
            setLoading(false);
        }
    }

    return (
    <div className="reset-password-background">
      <div className="reset-container">
        <h1>Reset Your Password</h1>
        <form onSubmit={handleSubmit}>
          <PasswordInput
            placeholder="New Password"
            value={password}
            onChange={(e:any) => setPassword(e.target.value)}
            name="Password"
          />
          <PasswordInput
            placeholder="Confirm Password"
            value={confirmPassword}
            onChange={(e:any) => setConfirmPassword(e.target.value)}
            name="ConfirmPassword"
          />
          <AuthButton content={loading ? 'Resetting...' : 'Reset Password'} disabled={loading || !password || !confirmPassword} />
        </form>
        {message && <p style={{ marginTop: '16px', fontSize: '14px' }}>{message}</p>}
      </div>
    </div>
  );
}


export default ResetPasswordPage;