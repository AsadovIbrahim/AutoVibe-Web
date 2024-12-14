import './LanguageSwitcher.scss'
import { useEffect } from 'react'
import { useTranslation } from 'react-i18next'
import globe from '/assets/images/icon/globe.svg'

const LanguageSwitcher = () => {
  const { i18n } = useTranslation();

  useEffect(() => {
    const savedLanguage = localStorage.getItem('selectedLanguage');
    if (savedLanguage) {
      i18n.changeLanguage(savedLanguage);
    }
  }, [i18n]);

  const changeLanguage = (lng:string) => {
    i18n.changeLanguage(lng);
    localStorage.setItem('selectedLanguage', lng);
  };

  return (
    <div style={{ display: 'flex', alignItems: 'center' }}>
      <img src={globe} />
      <select
        className='languageSelect'
        id="languageSelector"
        value={i18n.language}
        onChange={(e) => changeLanguage(e.target.value)}
      >
        <option value="en">EN</option>
        <option value="az">AZ</option>
        <option value="tr">TR</option>
        <option value="ru">RU</option>
      </select>
    </div>
  );
};

export default LanguageSwitcher;