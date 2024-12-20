import './PaginationButton.scss';
import { nextPage, prevPage, setPage } from '../../../services/state/actions';
import { useAppDispatch, useAppSelector } from '../../../hooks/useAppDispatch';
import { PaginationButtonProps } from '../../../types/PaginationButtonProps';

const PaginationButton = ({ content }: PaginationButtonProps) => {
  const dispatch = useAppDispatch();
  const totalPages = useAppSelector((state) => state.pagination.totalPages);
  const currentPage = useAppSelector((state) => state.pagination.currentPage) || 1;

  const handlePagination = () => {
    if (content === 'next-pagination' && currentPage <= totalPages) dispatch(nextPage());
    else if (content === 'back-pagination' && currentPage !== 1) dispatch(prevPage());
    else if (content !== 'back-pagination' && content !== 'next-pagination') dispatch(setPage(+content));
  };

  return (
    <button
      className={`pagination-btn ${
        currentPage.toString() === content ? 'selected' : ''
      }`}
      onClick={handlePagination}
    >
      {content === 'next-pagination' ? (
        <img src='/assets/images/icon/vector-right.svg' alt="Next" />
      ) : (
        <img src='/assets/images/icon/vector-left.svg' alt="Previous" />
      )}
    </button>
  );
};

export default PaginationButton;
