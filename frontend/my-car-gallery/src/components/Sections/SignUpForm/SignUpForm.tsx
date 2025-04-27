import './SignUpForm.scss';
import Input from '../../Common/Input/Input';
import AuthButton from '../../Common/AuthButton/AuthButton';
import OAuthButton from '../OAuthButton/OAuthButton';
import PasswordInput from '../PasswordInput/PasswordInput';
import { useState } from 'react';
import { Register } from '../../../services/api/AuthApiService';
import { useNavigate } from 'react-router-dom';

const SignUpForm = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    username: '',
    email: '',
    password: '',
    confirmPassword: ''
  });
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (formData.password !== formData.confirmPassword) {
      setError('Passwords do not match!');
      return;
    }

    setError('');
    setLoading(true);

    try {
      const result = await Register({
        firstName: formData.firstName,
        lastName: formData.lastName,
        username: formData.username,
        Email: formData.email,
        Password: formData.password,
        ConfirmPassword: formData.confirmPassword
      });

      if (result) {
        navigate('/confirm-email-info');
      }
    } catch (err: any) {
      setError(err?.message || 'Something went wrong. Please try again.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="black-screen">
      <div className="banner-section">
        <div className="container">
          <div className="left-section">
            <h1>
              Welcome to Auto<span className="vibe-text">Vibe</span>
            </h1>
          </div>

          <form onSubmit={handleSubmit}>
            <div className="signup-right-section">
              <div className="title-section">
                <p>Sign Up</p>
              </div>

              <OAuthButton />

              <div className="or-line">
                <hr />
                <p>or</p>
                <hr />
              </div>

              <div className="fullname-section">
                <Input
                  name="firstName"
                  value={formData.firstName}
                  onChange={handleInputChange}
                  placeholder="First Name"
                />
                <Input
                  name="lastName"
                  value={formData.lastName}
                  onChange={handleInputChange}
                  placeholder="Last Name"
                />
              </div>

              <div className="email-password-section">
                <Input
                  name="username"
                  value={formData.username}
                  onChange={handleInputChange}
                  placeholder="Username"
                />
                <Input
                  name="email"
                  value={formData.email}
                  onChange={handleInputChange}
                  placeholder="Email"
                />
                <PasswordInput
                  name="password"
                  value={formData.password}
                  onChange={handleInputChange}
                  placeholder="Password"
                />
                <PasswordInput
                  name="confirmPassword"
                  value={formData.confirmPassword}
                  onChange={handleInputChange}
                  placeholder="Confirm Password"
                />
              </div>

              {error && (
                <div className="error-message">
                  {error}
                </div>
              )}

              <div className="sign-up-btn">
                <AuthButton content={loading ? "Signing Up..." : "Sign Up"} disabled={loading} />
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default SignUpForm;
