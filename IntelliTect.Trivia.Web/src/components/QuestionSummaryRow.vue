<template>
  <tr
    :style="isSelected ? 'background-color: rgb(var(--v-theme-primary))' : ''"
  >
    <td>
      <v-checkbox v-model="isSelected" :value="questionSummary.id" />
    </td>
    <td>{{ questionSummary.text }}</td>
    <td>{{ questionSummary.hasCorrectAnswer }}</td>
    <td>{{ questionSummary.answerCount }}</td>
    <td>{{ Category[questionSummary.category ?? 0] }}</td>
  </tr>
</template>

<script setup lang="ts">
import { QuestionSummaryViewModel } from "@/viewmodels.g";
import { Category } from "@/models.g";

const props = defineProps<{
  questionSummary: QuestionSummaryViewModel;
}>();

const isSelected = ref(false);

const emit = defineEmits<{
  selectionChanged: [isSelected: boolean, id: string];
}>();

watch(isSelected, () => {
  emit("selectionChanged", isSelected.value, props.questionSummary.id!);
});
</script>
