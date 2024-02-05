
import { createStore } from 'vuex';
import { getItems } from '@/Helpers/Axios.ts';

export default createStore({
    state: {
        itemsWithReview: [],
    },
    mutations: {
        setItemsWithReview(state, items) {
            state.itemsWithReview = items;
        },
    },
    actions: {
        async fetchItemsWithReview({ commit }) {
            try {
                const items = await getItems();
                commit('setItemsWithReview', items);
            } catch (error) {
                console.error(error);
            }
        },
    },
    getters: {
        getItemsWithReview: (state) => state.itemsWithReview,
    },
});
