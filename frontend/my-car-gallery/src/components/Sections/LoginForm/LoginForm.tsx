import { useState } from 'react';
import './LoginForm.scss';
import Input from '../../Common/Input/Input';
import AuthButton from '../../Common/AuthButton/AuthButton';
import PasswordInput from '../PasswordInput/PasswordInput';
import { Login } from '../../../services/api/AuthApiService';
import { useAppDispatch } from '../../../hooks/useAppDispatch';
import { useNavigate } from 'react-router-dom';
import { setAuth } from '../../../services/authentication/authSlice';

const LoginForm = () => {
  const navigate = useNavigate(); 
  const dispatch=useAppDispatch();
  const [usernameOrEmail, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [errorMessage, setErrorMessage] = useState('');
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    if (!usernameOrEmail || !password) {
      setErrorMessage("Please fill in all fields.");
      return;
    }

    setIsLoading(true);
    setErrorMessage('');

    try {
      const response = await Login({ usernameOrEmail, password });
      dispatch(setAuth({
        user: response.user,
        accessToken: response.accessToken,
        profilePhoto: response.profilePhoto,
        isAuthenticated: true
      }));
      navigate('/');
    } catch (error) {
      console.error('Login failed:', error);
      setErrorMessage('Invalid username/email or password.');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="black-screen">
      <div className="banner-section">
        <div className="container">
          <div className="left-section">
            <h1>Welcome to Auto<span className="vibe-text">Vibe</span></h1>
          </div>

          <form onSubmit={handleSubmit}>
            <div className="right-section">
              <div className="title-section">
                <p>Sign In</p>
              </div>

              <div className="input-section">
                <Input
                  placeholder="Username or email"
                  value={usernameOrEmail}
                  onChange={(e) => setEmail(e.target.value)}
                  name={usernameOrEmail}
                />
                <PasswordInput
                  value={password}
                  onChange={(e:any) => setPassword(e.target.value)}
                />
              </div>

              <div className="second-section">
                <div className="remember-me">
                  <input type="checkbox" />
                  <p>Remember-me</p>
                </div>
                <div className="forgot-password">
                  <a href="">Forgot Password?</a>
                </div>
              </div>

              {errorMessage && <div className="error-message">{errorMessage}</div>}

              <div className="sign-in-btn">
                <AuthButton content={isLoading ? 'Signing In...' : 'Sign In'} disabled={false} />
              </div>

              <div className="first-time-text">
                <a href="/register">First time here? Create an AutoVibe account</a>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginForm;
