import "./Navbar.scss";
import { Link, NavLink } from "react-router-dom";
import LanguageSwitcher from "../LanguageSwitcher/LanguageSwitcher";
import { useAppSelector, useAppDispatch } from "../../../hooks/useAppDispatch";
import { useState } from "react";
import { Logout } from "../../../services/authentication/authSlice";
import Swal from "sweetalert2";

const Navbar = () => {
  const dispatch = useAppDispatch();
  const profilePhoto = useAppSelector((state) => state.auth.profilePhoto);
  const isAuthenticated = useAppSelector((state) => state.auth.isAuthenticated);
  const [isDropdownOpen, setDropdownOpen] = useState(false);

  const handleLogout = () => {
    Swal.fire({
      title: "Are you sure you want to log out?",
      text: "If you log out, you will need to log in again to access your account.",
      icon: "warning",  
      showCancelButton: true,  
      confirmButtonColor: "#3085d6",  
      cancelButtonColor: "#d33", 
      confirmButtonText: "Yes, log me out",
      cancelButtonText: "Cancel",
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch(Logout()); 
      }
    });
  };

  return (
    <nav className="navbar">
      <div className="logo">
        <Link to="/">
          <img src="/assets/images/icon/autovibe-icon.svg" alt="AutoVibe Logo" />
          <span className="brand-name">Auto<span className="highlight">Vibe</span></span>
        </Link>
      </div>

      <ul className="nav-links">
  <li>
    <NavLink
      to="/"
      className={({ isActive }) => (isActive ? "active-link" : "")}
      end
    >
      Home
    </NavLink>
  </li>
  <li>
    <NavLink
      to="/about"
      className={({ isActive }) => (isActive ? "active-link" : "")}
    >
      About
    </NavLink>
  </li>
  <li>
    <NavLink
      to="/gallery"
      className={({ isActive }) => (isActive ? "active-link" : "")}
    >
      Gallery
    </NavLink>
  </li>
  <li>
    <NavLink
      to="/contact"
      className={({ isActive }) => (isActive ? "active-link" : "")}
    >
      Contact
    </NavLink>
  </li>
</ul>


      <div className="right-section">
        <LanguageSwitcher />
        {!isAuthenticated ? (
          <div className="auth">
            <Link to="/login" className="sign-in-btn">Sign In</Link>
          </div>
        ) : (
          <div className="profile-section">
            <img
              src={profilePhoto || "/assets/images/icon/autovibe-icon.svg"}
              alt="Profile"
              className="profile-photo"
              onClick={() => setDropdownOpen(!isDropdownOpen)}
            />
            {isDropdownOpen && (
              <div className="profile-dropdown">
                <Link to="/profile" onClick={() => setDropdownOpen(false)}>Profile Settings</Link>
                <button onClick={handleLogout}>Log Out</button>
              </div>
            )}
          </div>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
