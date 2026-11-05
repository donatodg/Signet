interface Props {
  value: string;
  onChange: (v: string) => void;
  placeholder?: string;
  className?: string;
}

/** Caja de búsqueda con botón ✕ para borrar el texto. */
export function SearchBox({ value, onChange, placeholder, className = '' }: Props) {
  return (
    <div className={`search-box ${className}`}>
      <input className="filter" placeholder={placeholder} value={value}
        onChange={(e) => onChange(e.target.value)}
        onKeyDown={(e) => e.key === 'Escape' && value && onChange('')} />
      <button type="button" className="search-clear" title="Borrar" aria-label="Borrar búsqueda" disabled={!value}
        onClick={(e) => { onChange(''); (e.currentTarget.previousElementSibling as HTMLInputElement | null)?.focus(); }}>✕</button>
    </div>
  );
}
