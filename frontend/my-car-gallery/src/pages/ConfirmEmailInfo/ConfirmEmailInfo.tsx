import { useNavigate } from 'react-router-dom';
import './ConfirmEmailInfo.scss';

const ConfirmEmailInfo = () => {
  const navigate = useNavigate();

  return (
    <div className="confirm-email-container">
      <div className="confirm-email-card">
        <h2>Check Your Email</h2>
        <p>We have sent a confirmation link to your email address. Please confirm your email to continue.</p>
        <button onClick={() => navigate('/login')}>Back to Login</button>
      </div>
    </div>
  );
};

export default ConfirmEmailInfo;
